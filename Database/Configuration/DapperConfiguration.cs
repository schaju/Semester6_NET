using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap;
using Database.Mapper;

namespace Database
{
    public class DapperConfiguration
    {
        private static bool mapped;

        public static void Map()
        {
            if (mapped)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new UserAccountMapper());
            });
        }
    }
}
