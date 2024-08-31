using System;
using System.Collections.Generic;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace LassoRegressionExample
{
    public class HouseData
    {
        public float Size { get; set; }                   // Tamanho em m²
        public float Rooms { get; set; }                  // Número de quartos
        public float Bathrooms { get; set; }              // Número de banheiros
        public float Age { get; set; }                    // Idade da casa
        public float DistanceToCenter { get; set; }       // Distância até o centro
        public float NearbySupermarkets { get; set; }     // Número de supermercados próximos
        public float DayOfWeek { get; set; }              // Dia da semana em que a casa foi anunciada (0 = Domingo, 6 = Sábado)
        public float Price { get; set; }                  // Preço da casa
    }

    public class HousePricePrediction
    {
        [ColumnName("Score")]
        public float PredictedPrice { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext();

            var houseData = new List<HouseData>
            {
                new HouseData { Size = 50, Rooms = 2, Bathrooms = 1, Age = 10, DistanceToCenter = 5, NearbySupermarkets = 2, DayOfWeek = 1, Price = 200000 },
                new HouseData { Size = 75, Rooms = 3, Bathrooms = 2, Age = 8, DistanceToCenter = 7, NearbySupermarkets = 3, DayOfWeek = 3, Price = 300000 },
                new HouseData { Size = 100, Rooms = 4, Bathrooms = 2, Age = 5, DistanceToCenter = 10, NearbySupermarkets = 1, DayOfWeek = 2, Price = 400000 },
                new HouseData { Size = 120, Rooms = 4, Bathrooms = 3, Age = 2, DistanceToCenter = 3, NearbySupermarkets = 4, DayOfWeek = 5, Price = 600000 },
                new HouseData { Size = 200, Rooms = 5, Bathrooms = 4, Age = 1, DistanceToCenter = 8, NearbySupermarkets = 5, DayOfWeek = 0, Price = 900000 },
            };

            var dataView = mlContext.Data.LoadFromEnumerable(houseData);

            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Size", "Rooms", "Bathrooms", "Age", "DistanceToCenter", "NearbySupermarkets", "DayOfWeek" })
                    .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression(
                        labelColumnName: "Price",
                        featureColumnName: "Features",
                        l1Regularization: 0.01f,  // Regularização L1 (Lasso)
                        l2Regularization: 0f));   // Sem regularização L2 (Ridge)

            // Treina o modelo
            var model = pipeline.Fit(dataView);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<HouseData, HousePricePrediction>(model);

            // Nova casa para prever o preço
            var newHouse = new HouseData
            {
                Size = 80,
                Rooms = 3,
                Bathrooms = 2,
                Age = 5,
                DistanceToCenter = 6,
                NearbySupermarkets = 2,
                DayOfWeek = 4  // Exemplo: Quinta-feira
            };

            var prediction = predictionEngine.Predict(newHouse);

            Console.WriteLine($"O preço previsto para a casa é: R$ {prediction.PredictedPrice}");
        }
    }
}