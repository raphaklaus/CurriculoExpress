using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using System.Web;
using CurriculoExpressDomain;

namespace CurriculoExpressInfra
{
    public class UsuarioMap : ClassMap<UsuarioRegistro>
    {
        public UsuarioMap()
        {
            Table("Usuarios");
            Id(x => x.id).Index("idx_primario")
                .GeneratedBy.Identity()
                .UnsavedValue(0);

            Map(x => x.CPF).Length(11).Unique().Not.Nullable();
            Map(x => x.Senha).Length(20).Not.Nullable();

        }
    }
}