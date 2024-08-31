using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace LinearRegressionExample
{
    // Classe que define o formato dos dados, com os campos `Investment` (Investimento) e `Sales` (Vendas).
    public class SalesData
    {
        public float Investment { get; set; }  // Investimento em publicidade
        public float Sales { get; set; }       // Vendas
    }

    // Classe que define a previsão de vendas que o modelo irá produzir.
    public class SalesPrediction
    {
        [ColumnName("Score")]
        public float PredictedSales { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            // Dados de exemplo com histórico de investimentos em publicidade e vendas correspondentes
            var data = new List<SalesData>
            {
                new SalesData { Investment = 1000f, Sales = 10000f },
                new SalesData { Investment = 1500f, Sales = 12000f },
                new SalesData { Investment = 2000f, Sales = 15000f },
                new SalesData { Investment = 2500f, Sales = 18000f },
                new SalesData { Investment = 3000f, Sales = 20000f }
            };

            // Carrega os dados no IDataView, que é o formato usado pelo ML.NET
            var dataView = mlContext.Data.LoadFromEnumerable(data);

            // Cria o pipeline de treinamento
            // Este pipeline concatena os dados de "Investment" em uma única coluna chamada "Features"
            // e aplica a técnica de regressão para prever as vendas ("Sales")
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Investment" })
                .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression(labelColumnName: "Sales", featureColumnName: "Features"));

            // Treina o modelo usando os dados de exemplo
            var model = pipeline.Fit(dataView);

            // Cria uma engine de previsão que pode ser usada para fazer previsões em novos dados
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SalesData, SalesPrediction>(model);

            // Novo investimento para o qual queremos prever as vendas
            var newInvestment = new SalesData { Investment = 3500f };

            // Previsão das vendas para o novo investimento
            var prediction = predictionEngine.Predict(newInvestment);

            // Exibe a previsão
            Console.WriteLine($"Se você investir R$ {newInvestment.Investment}, a previsão de vendas é de R$ {prediction.PredictedSales}");
        }
    }
}