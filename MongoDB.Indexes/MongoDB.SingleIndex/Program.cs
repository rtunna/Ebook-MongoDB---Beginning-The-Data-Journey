using MongoDB.Bson;
using MongoDB.Driver;

try
{
    var client = new MongoClient("mongodb://localhost:27017");
    var database = client.GetDatabase("Ebook");
    var collection = database.GetCollection<BsonDocument>("PeopleTestData");

    // Create a single field index on the 'surname' field
    var indexKeysDefinition = Builders<BsonDocument>.IndexKeys.Ascending("surname");
    collection.Indexes.CreateOne(new CreateIndexModel<BsonDocument>(indexKeysDefinition));

    Console.WriteLine("Index Added Successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Failed {ex.Message}");
}

