using System.Data;
using System.Xml;
using System.Xml.Schema;
using QuikGraph;
using QuikGraph.Data;

#region tries to get db schema. didn't find a proper way.
//using var connection = new Npgsql.NpgsqlConnection("Host=localhost;Database=tbpm-api-db;Username=postgres;Password=postgres");
//connection.Open();
//var table = connection.GetSchema();

//using MemoryStream ms = new MemoryStream();
////using TextWriter tw = new StreamWriter(ms);
//connection.GetSchema().WriteXml(ms, true);
////var sch = XmlSchema.Read(ms, ValidationCallback);
////string xml = sch.ToString();
////using StreamReader reader = new StreamReader(ms);
////string text = reader.ReadToEnd();

////DataTable dt = connection.GetSchema("ForeignKeys");

//DataTable tblSchema;
//using (Npgsql.NpgsqlCommand cmd = connection.CreateCommand())
//{
//    cmd.CommandType = CommandType.Text;
//    cmd.CommandText = $"SELECT * FROM data.\"Employees\"";
//    using (Npgsql.NpgsqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.KeyInfo))
//    {
//        tblSchema = rdr.GetSchemaTable();
//    }
//}
//int numColumns = tblSchema.Columns.Count;
//foreach (DataRow dr in tblSchema.Rows)
//{
//    Console.WriteLine("{0}: {1}", dr["ColumnName"], dr["DataType"]);
//}
////StringReader xmlSR = new System.IO.StringReader(text);
//ms.Seek(0, System.IO.SeekOrigin.Begin);
//var dataSet = new DataSet();
//dataSet.ReadXmlSchema(ms);
////dataSet.ReadXml(xmlSR);

////var adapter = new Npgsql.NpgsqlDataAdapter($"SELECT * FROM data.\"Employees\"", connection);
////adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

////foreach (DataRow row in table.Rows)
////{
////    string schema = "";
////    string tableName = "";
////    foreach (DataColumn col in table.Columns)
////    {
////        if (col.ColumnName == "table_schema")
////        {
////            schema = row[col].ToString();
////        }
////        if (col.ColumnName == "table_name")
////        {
////            tableName = row[col].ToString();
////        }


////    }
////    adapter.SelectCommand!.CommandText = $"SELECT * FROM {schema}.\"{tableName}\"";
////    adapter.FillSchema(dataSet, SchemaType.Source, tableName);
////    Console.WriteLine("============================");
////}

////adapter.SelectCommand!.CommandText = $"SELECT * FROM data.\"Persons\"";
////adapter.FillSchema(dataSet, SchemaType.Source, "Persons");

//DataSetGraph graph = dataSet.ToGraph();

//string dot = graph.ToGraphviz();
//Console.WriteLine(dot);
//Console.ReadKey();

//connection.Close();


//static void ValidationCallback(object sender, ValidationEventArgs args)
//{
//    if (args.Severity == XmlSeverityType.Warning)
//        Console.Write("WARNING: ");
//    else if (args.Severity == XmlSeverityType.Error)
//        Console.Write("ERROR: ");

//    Console.WriteLine(args.Message);
//}
#endregion


#region

/*
 * Docs is available here: https://github.com/KeRNeLith/QuikGraph/wiki
 1. Build a singleton service class (for example GraphService) that will wrap graph instance (Facade pattern may work out). Note: wtite operations should be thread safe because graph doesn't support it!
 2. The GraphService may contain some sophisticated internal intermediate classes and logic. However, its public API should be very simple and limited.
 3. 
 */

var graph = new BidirectionalGraph<string, Edge<string>>();
graph.AddVertex("persons");
graph.AddVertex("employees");
graph.AddVertex("positions");
graph.AddVertex("department");
graph.AddEdge(new Edge<string>("persons", "employees"));
graph.AddEdge(new Edge<string>("employees", "positions"));
graph.AddEdge(new Edge<string>("positions", "department"));
graph.AddEdge(new Edge<string>("employees", "department"));

foreach (var vertex in graph.Vertices)
{
    Console.WriteLine($"vertex: {vertex}");
    Console.WriteLine($"out edges".PadLeft(15, '_'));
    printEdges(graph.OutEdges(vertex));
    Console.WriteLine($"in edges".PadLeft(15, '_'));
    printEdges(graph.InEdges(vertex));
}


void printEdges(IEnumerable<Edge<string>> edges)
{
    foreach (var edge in edges)
    {
        Console.WriteLine(edge.ToString().PadLeft(30));
    }
}
#endregion
