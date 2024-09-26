double VectorSize(int[] vector, int size, int[][] matrix)
{
    int[] matrixA;
    matrixA = new int[size];
    int sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum = 0;
        for (int j = 0; j < size; j++)
        {
            sum += vector[j] * matrix[j][i];
        }
        matrixA[i] = sum;
    }
    sum = 0;
    for (int i = 0; i < size; i++)
    {
        sum += matrixA[i] * vector[i];
    }
    return Math.Sqrt(sum);
}
int Symmetry(int size, int[][] matrix)
{
    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            if (matrix[i][j] != matrix[j][i])
            {
                return 0;
            }
        }
    }
    return 1;
}
string text = "21.txt";
string? t;
int size = 0;
int[] vector = new int[0];
int[][] matrix = new int[0][];
try
{
    StreamReader str = new StreamReader(text);
    size = Convert.ToInt32(str.ReadLine());
    vector = new int[size];
    matrix = new int[size][];
    for (int i = 0; i < size; ++i)
    {
        t = str.ReadLine();
        matrix[i] = t.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    }
    t = str.ReadLine();
    vector = t.Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
    str.Close();
}
catch (Exception sms)
{
    Console.WriteLine("exception" + sms.Message);
}
if (Symmetry(size, matrix) == 1)
{
    Console.WriteLine("Симетричнная матрица:");
}
if (Symmetry(size, matrix) == 1)
{
    Console.WriteLine("Ответ:");
    Console.WriteLine(VectorSize(vector, size, matrix));
}
