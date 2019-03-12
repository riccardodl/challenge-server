using Broker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Data
{
    public class DbInitalizer
    {
        public static void Initialize(ShipContext context)
        {
            if (context.Ships.Any())
            {
                return;
            }
            var ships = new Ship[]
            {
                new Ship{ Name="Nostromus",Ropes=new List<Rope>{ }},
                new Ship{ Name="Queen Mary",Ropes=new List<Rope>{ }},
                new Ship{ Name="Argo",Ropes=new List<Rope>{ } }
            };
            foreach(Ship s in ships)
            {
                context.Ships.Add(s);
            }
            context.SaveChanges();

            var ropes = new Rope[]
            {
            new Rope{Tag=TagsEnum.unspecified.GetDisplayName(),CaptureDate=DateTime.Parse("2019-12-03")},
            new Rope{Tag=TagsEnum.unspecified.GetDisplayName(),CaptureDate=DateTime.Parse("2019-12-03")},
            new Rope{Tag=TagsEnum.unspecified.GetDisplayName(),CaptureDate=DateTime.Parse("2019-12-03")},
            new Rope{Tag=TagsEnum.unspecified.GetDisplayName(),CaptureDate=DateTime.Parse("2019-12-03")}
            };
            foreach (Rope r in ropes)
            {
                context.Ropes.Add(r);
            }
            context.SaveChanges();

        }
    }
}
