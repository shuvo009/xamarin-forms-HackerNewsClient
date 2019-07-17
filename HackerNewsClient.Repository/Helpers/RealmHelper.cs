using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerNewsClient.Repository.Helpers
{
    public class RealmHelper
    {
        private static ulong schemaVersion = 1;
        public static RealmConfiguration GetRealmConfiguration()
        {
            return new RealmConfiguration() { SchemaVersion = schemaVersion };

        }

    }
}
