using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace LogisticRegressionExample
{
    // Classe que representa os dados de crédito do cliente
    public class CreditData
    {
        public float Income { get; set; }            // Renda anual do cliente
        public float LoanAmount { get; set; }        // Valor do empréstimo solicitado
        public float CreditScore { get; set; }       // Pontuação de crédito do cliente
        public bool IsGoodCredit { get; set; }       // Se o cliente é um bom pagador (true = sim, false = não)
    }

    // Classe que representa a previsão feita pelo modelo
    public class CreditPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool IsGoodCredit { get; set; }       // Previsão se o cliente é um bom pagador
        public float Probability { get; set; }       // Probabilidade da previsão ser verdadeira
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext(); // Inicializa o contexto do ML.NET

            // Dados de exemplo para treinar o modelo
            var creditData = new List<CreditData>
            {
                new CreditData { Income = 50000, LoanAmount = 20000, CreditScore = 650, IsGoodCredit = true },
                new CreditData { Income = 30000, LoanAmount = 25000, CreditScore = 600, IsGoodCredit = false },
                new CreditData { Income = 70000, LoanAmount = 30000, CreditScore = 700, IsGoodCredit = true },
                new CreditData { Income = 25000, LoanAmount = 10000, CreditScore = 550, IsGoodCredit = false },
                new CreditData { Income = 45000, LoanAmount = 15000, CreditScore = 680, IsGoodCredit = true },
            };

            // Carrega os dados em um IDataView, que é o formato de dados usado pelo ML.NET
            var dataView = mlContext.Data.LoadFromEnumerable(creditData);

            // Configura o pipeline de treinamento
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Income", "LoanAmount", "CreditScore" }) // Combina as colunas de entrada em uma única coluna de características
                .Append(mlContext.Transforms.NormalizeMinMax("Features")) // Normaliza as características para que todas estejam na mesma escala
                .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "IsGoodCredit", featureColumnName: "Features")); // Aplica o modelo de Regressão Logística

            // Treina o modelo com os dados de exemplo
            var model = pipeline.Fit(dataView);

            // Cria um engine de previsão para fazer previsões com novos dados
            var predictionEngine = mlContext.Model.CreatePredictionEngine<CreditData, CreditPrediction>(model);

            // Novo cliente para prever se é bom pagador
            var newClient = new CreditData { Income = 55000, LoanAmount = 20000, CreditScore = 670 };
            var prediction = predictionEngine.Predict(newClient); // Faz a previsão com o modelo treinado

            // Exibe o resultado da previsão
            Console.WriteLine($"O cliente provavelmente é um bom pagador? {prediction.IsGoodCredit} (Probabilidade: {prediction.Probability:P2})");
        }
    }
}