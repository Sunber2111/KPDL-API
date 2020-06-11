

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Algorithm.FPGrowth;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AI
{
    public class FPGrowth
    {
        public class Query : IRequest<List<List<string>>>
        {

        }

        public class Handler : IRequestHandler<Query, List<List<string>>>
        {
            private readonly DataContext db;
            public Handler(DataContext db)
            {
                this.db = db;
            }

            public async Task<List<List<string>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // handler logic here
                var query = (db.Orders.Select(x => new Data { Id = x.StudentId, IdProduct = x.SubjectId })).ToList();

                FPG alo = new FPG(query, 8);

                var convert2Word = new List<List<string>>();

                var minConf = 0.5;

                await alo.Run();

                foreach (var i in alo.TreeTraining.FP_Condition)
                {
                    foreach (var j in i.Value)
                    {
                        if (j.ListCP.Count <= 4)
                        {
                            var str = await TranslateToWord2(j, minConf, alo.Histogram, alo.FinalData.Count, Math.Round((double)j.Value / (double)query.Count, 2, MidpointRounding.AwayFromZero));
                            if (str.Count > 0)
                                convert2Word.Add(str);
                        }
                    }
                }
                return convert2Word;
            }

            private async Task<List<string>> TranslateToWord(CP cp, double minConf, Dictionary<int, int> his, int sumTransaction, double append)
            {
                var result = new List<string>();
                var ds = new Dictionary<int, Subject>();
                var sub = new Subject();
                foreach (var i in cp.ListCP)
                {
                    sub = await db.Subjects.SingleOrDefaultAsync(x => x.Id == i);
                    ds.Add(sub.Id, sub);
                }

                double percent = Math.Round((double)cp.Value / (double)his[ds.ElementAt(0).Key], 2, MidpointRounding.AwayFromZero);

                if (percent >= minConf)
                {
                    result.Add($"{Math.Round(percent * 100.0, 2)}% Những người mua khóa học {ds[cp.ListCP[0]].Name} sẽ mua {ds[cp.ListCP[1]].Name}");
                }
                percent = Math.Round((double)cp.Value / (double)his[ds.ElementAt(1).Key], 2, MidpointRounding.AwayFromZero);
                if (percent >= minConf)
                {
                    result.Add($"{Math.Round(percent * 100.0, 2)}% Những người mua khóa học {ds[cp.ListCP[1]].Name} sẽ mua {ds[cp.ListCP[0]].Name}");
                }
                if (result.Count >= 1)
                {
                    result.Insert(0, $"Với {cp.Value} tổng số lần xuất hiện, chiếm {Math.Round(append * 100, 2)}% trong giao dịch, với sản phẩm {ds[cp.ListCP[0]].Name} và {ds[cp.ListCP[1]].Name} thì:");
                }

                return result;
            }

            private async Task<List<string>> TranslateToWord2(CP cp, double minConf, Dictionary<int, int> his, int sumTransaction, double append)
            {
                var result = new List<string>();
                var ds = new Dictionary<int, Subject>();
                var rest = new Dictionary<int, Subject>();
                var sub = new Subject();
                double percent = 0;
                foreach (var i in cp.ListCP)
                {
                    sub = await db.Subjects.SingleOrDefaultAsync(x => x.Id == i);
                    ds.Add(sub.Id, sub);
                }

                foreach (var i in ds)
                {
                    rest = new Dictionary<int, Subject>(ds.Where(x => x.Key != i.Key));
                    percent = Math.Round((double)cp.Value / (double)his[i.Key], 2, MidpointRounding.AwayFromZero);
                    if (percent >= minConf)
                    {
                        var restItem = "";
                        foreach (var j in rest)
                        {
                            restItem += $" {j.Value.Name},";
                        }
                        result.Add($"{Math.Round(percent * 100.0, 2)}% Những người mua khóa học {i.Value.Name} sẽ mua{restItem}");
                    }
                }

                if (result.Count >= 1)
                {
                    var restItem = "";
                    var isAdd = true;
                    foreach (var j in ds)
                    {
                        if(isAdd)
                        {
                            restItem += $"{j.Value.Name}";
                            isAdd = false;
                            continue;
                        }
                        restItem += $", {j.Value.Name}";
                    }
                    result.Insert(0, $"Với {cp.Value} tổng số lần xuất hiện, chiếm {Math.Round(append * 100, 2)}% trong giao dịch, với sản phẩm {restItem} thì:");
                }

                return result;
            }
        }
    }
}