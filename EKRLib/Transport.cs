
namespace EKRLib
{
    abstract public class Transport
    {
        /// <summary>
        /// Класс проверяет корректность данных и в случае успеха присваивает строковым свойствам данные
        /// </summary>
        /// <param name="model">  Модель транспорта</param>
        /// <param name="power"> Мощность транспорта</param>
        /// <exception cref="TransportException"></exception>
        public Transport(string model, uint power)
        {
            bool f = true;

            if (model.Length == 5)
            {
                for (int i = 0; i < model.Length; i++)
                {
                    if ((!Char.IsUpper(model[i]) == true) && (!int.TryParse(model[i].ToString(), out int p)))
                    {
                        f = false;
                    }
                }

                if (f == false)
                {
                    throw new TransportException(message: $"Недопустимая модель {model}");
                }
                else
                {
                    Model = model;
                }
            }
            else
            {
                throw new TransportException(message: $"Недопустимая модель {model}");
            }


            if (power < 20)
            {
                throw new TransportException(message: "мощность не может быть меньше 20 л.с.");
            }
            else
            {
                Power = power;
            }
        }

        protected string Model { set ; get; }

        protected uint Power { set; get; }

        abstract public string StartEngine();
      
        public override string ToString()
        {
            return $"Model:{Model}, Power:{Power}".ToString();
        }
    }  
}