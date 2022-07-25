namespace ValidationBusiness;

public class InputValidations
{
    /// <summary>
    /// Validates Menu INPUT
    /// </summary>
    /// <param name="minNumber"></param>
    /// <param name="maxNumber"></param>
    /// <param name="choosenNumber"></param>
    /// <returns></returns>
    public static bool CheckMenuInput(int minNumber, int maxNumber, string? choosenNumber)
    {
        int numeroEscolhido = 0;

        //Validating if INPUT is null
        if (choosenNumber is null)
        {
            return false;
        }

        //Validating if INPUT is a valid number
        if (!int.TryParse(choosenNumber, out numeroEscolhido))
        {
            return false;
        }

        //Validating if INPUT is in the menu array
        if (numeroEscolhido < minNumber || numeroEscolhido > maxNumber)
        {
            return false;
        }

        return true;
    }
}