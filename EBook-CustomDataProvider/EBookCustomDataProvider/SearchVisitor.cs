using Microsoft.Xrm.Sdk.Query;

namespace EBookCustomDataProvider
{
    public class SearchVisitor : IQueryExpressionVisitor
    {
        public string SearchKeyWord { get; private set; }

        public QueryExpression Visit(QueryExpression query)
        {
            //Returning null will get a random result
            if (query.Criteria.Conditions.Count == 0)
                return null;

            //Get the first filter value
            SearchKeyWord = query.Criteria.Conditions[0].Values[0].ToString();

            return query;
        }
    }
}
