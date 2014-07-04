using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using System.Web;
using CurriculoExpressDomain;

namespace CurriculoExpressInfra
{
    public class CurriculoMap : ClassMap<Curriculo>
    {
        public CurriculoMap()
        {
            Table("Curriculos");
            Id(x => x.id).Index("idx_primario")
                .GeneratedBy.Identity()
                .UnsavedValue(0);

            Map(x => x.Nome).Length(40).Not.Nullable();;
            Map(x => x.CPF).Length(11).Not.Nullable().Unique();
            Map(x => x.Identidade).Length(9).Unique();
            Map(x => x.OrgaoEmissor).Length(5).Not.Nullable();
            Map(x => x.Endereco).Length(255).Not.Nullable();
            Map(x => x.Cidade).Length(50).Not.Nullable();
            Map(x => x.Estado).Length(2).Not.Nullable(); ;

        }
    }
}