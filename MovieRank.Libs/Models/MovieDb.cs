using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace MovieRank.Libs.Models
{
    [DynamoDBTable("MovieRank")]
    public class MovieDb
    {
        [DynamoDBHashKey]
        public int UserId { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey]
        public string MovieName { get; set; }
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public int Ranking { get; set; }
        public string RankedDateTime { get; set; }
    }
}
