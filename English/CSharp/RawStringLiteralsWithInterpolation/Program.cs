string name = "John";
int age = 30;

string json = $$"""
{
    "Name": "{{name}}",
    "Age": {{age}}
}
""";

Console.WriteLine(json);