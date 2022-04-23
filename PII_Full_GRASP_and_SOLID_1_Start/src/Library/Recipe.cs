//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

// calcular el costo total de producir un producto final
        public double GetProductionCost()
        {
            double Costo_insumos = 0;
            double Costo_equipamiento = 0;
            double Costo_total;

            foreach (Step step in this.steps)
            {
                Costo_insumos = Costo_insumos + (step.Quantity * step.Input.UnitCost); //falta precio unitario
                Costo_equipamiento = Costo_equipamiento + (step.Equipment.HourlyCost * step.Time);
            }

            Costo_total = Costo_insumos + Costo_equipamiento;
            
            return Costo_total;
        }

        //¿Qué patrón o principio usan para asignar esta responsabilidad?

        //utiliza el principio expert, la clase que tiene la información necesaria para poder cumplir con la responsabilidad
        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            Console.WriteLine($"El precio de producir {this.FinalProduct.Description} es de {this.GetProductionCost()}");
        }
    }
}