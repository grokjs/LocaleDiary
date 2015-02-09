using System;
using System.Collections.Generic;

namespace LocaleDiary.Tests.Unit.Infrastructure
{
    public class GuidList : List<Guid>
    {
        private readonly Guid[] _guids =
        {
            new Guid("fb007022-d618-4ecd-a407-0edafa34cd9f"),
            new Guid("57fe1740-4e9e-4044-aba8-e435baf6cfd0"),
            new Guid("ae0b6586-56a5-4c02-b4f0-34dc2d7bacdb"),
            new Guid("326c67f8-e4e3-44c4-ab7d-14094c9ed008"),
            new Guid("b1a8e6c1-13df-4032-a0a1-03ca5bc43000"),
            new Guid("94185e57-54cd-4521-985d-925a196c0447"),
            new Guid("64639bc8-2408-4765-b7bd-73d290f9c368"),
            new Guid("31629314-0fbc-4cef-a0f7-59a966ad98bf"),
            new Guid("7b5cf9b0-27ab-4e74-9269-6dc195c3b3e9"),
            new Guid("f5c947a8-5b0a-4792-b5aa-6496168f980e")
        };

        public GuidList()
        {
            AddRange(_guids);
        }
    }
}