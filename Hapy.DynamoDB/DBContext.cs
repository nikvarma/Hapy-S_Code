using Amazon.DynamoDBv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapy.DynamoDB
{
    public class DBContext: AmazonDynamoDBClient
    {
        private AmazonDynamoDBClient amazonDynamoDB;
        public DBContext(): base()
        {

        }
    }
}
