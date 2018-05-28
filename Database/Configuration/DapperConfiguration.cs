using System;
using System.Collections.Generic;
using System.Text;
using Dapper.FluentMap;
using Database.Mapper;

namespace Database
{
    public static class DapperConfiguration
    {
        private static bool mapped;

        public static void Initialize()
        {
            if (mapped)
            {
                return;
            }
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new ChatMapper());
                config.AddMap(new ChatMemberMapper());
                config.AddMap(new ChatMessageMapper());
                config.AddMap(new UserAccountMapper());

            });
        }
    }
}
