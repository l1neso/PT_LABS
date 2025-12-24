public class Box
{
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get { return length; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Длина должна быть положительным числом.");
            }
            length = value;
        }
    }

    public double Width
    {
        get { return width; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Ширина должна быть положительным числом.");
            }
            width = value;
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Высота должна быть положительным числом.");
            }
            height = value;
        }
    }

    public bool IsClosable { get; set; }


    public Box(double l, double w, double h, bool isClosable)
    {
        Length = l;
        Width = w;
        Height = h;
        IsClosable = isClosable;
    }


    public bool IsFit(double l, double w, double h)
    {
        
        double[] thisBoxDims = { Length, Width, Height };
        double[] otherBoxDims = { l, w, h };

        Array.Sort(thisBoxDims);
        Array.Sort(otherBoxDims);

        return thisBoxDims[0] >= otherBoxDims[0] &&
               thisBoxDims[1] >= otherBoxDims[1] &&
               thisBoxDims[2] >= otherBoxDims[2];
    }


    
    public void PrintBox()
    {
        string closableStatus = IsClosable ? "Закрываемая" : "Открытая";
        Console.WriteLine($"--- Информация о коробке ---");
        Console.WriteLine($"Размеры (ДхШхВ): {Length}x{Width}x{Height}");
        Console.WriteLine($"Тип: {closableStatus}");
        Console.WriteLine("--------------------------\n");
    }
}