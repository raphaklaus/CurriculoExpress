using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Cfg;

namespace CurriculoExpressInfra
{
  public class Conexao
  {
    private static ISessionFactory _sessionFactory;

    public static void ConstruirMapeamento(MappingConfiguration mappingConfiguration)
    {
      mappingConfiguration.FluentMappings.Add<UsuarioMap>();
      mappingConfiguration.FluentMappings.Add<CurriculoMap>();
    }


    private static ISessionFactory SessionFactory()
    {
        if (_sessionFactory == null)
          InicializaSessao();

        return _sessionFactory;
    }

    private static void MigrarDados(Configuration cfg, bool CriarBaseDeDados)
    {
      if (CriarBaseDeDados)
      {
        var migration = new SchemaExport(cfg);
        migration.Create(true, true);
      }
      else
      {
        var update = new SchemaUpdate(cfg);
        update.Execute(true, true);
      }
    }

    private static void InicializaSessao()
    {
        FluentConfiguration configuration = Fluently.Configure()
            .Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c => c
                .Host("localhost")
                .Port(5432)
                .Database("CurriculoExpress")
                .Username("postgres")
                .Password("123456"))
            )
            .ExposeConfiguration(cfg => MigrarDados(cfg, false))
            .Mappings(ConstruirMapeamento);

        _sessionFactory = configuration.BuildSessionFactory();
    }

    public static ISession AbrirSessao()
    {
      return SessionFactory().OpenSession();
    }
  }
}