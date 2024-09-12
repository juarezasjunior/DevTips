string nome = "João";
int idade = 30;

string json = $$"""
{
    "Nome": "{{nome}}",
    "Idade": {{idade}}
}
""";

Console.WriteLine(json);