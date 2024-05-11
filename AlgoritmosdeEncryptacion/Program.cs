// See https://aka.ms/new-console-template for more information


int option = 0;
while(option != 3)
{
    Console.WriteLine("---------- MENU -----------");

    Console.WriteLine("1. Cifrado Cesar");
    Console.WriteLine("2. Cifrado Vigenere");
    Console.WriteLine("3. Salir");

    Console.WriteLine("Por favor, ingrese una opción:");
    option = Convert.ToInt32(Console.ReadLine());



    switch (option)
    {
        case 1:

            int actionType = 0; 
            Console.WriteLine("Cifrado Cesar");
            Console.WriteLine("1. Encryptar");
            Console.WriteLine("2. Desencryptar");


            Console.WriteLine("Por favor, ingrese una opción:");
            actionType = Convert.ToInt32(Console.ReadLine());

            switch (actionType)
            {
                case 1:
                    Console.WriteLine("Por favor, ingrese una frase:");
                    string encryptPhrase = CifradoCesar(Console.ReadLine(),true);
                    Console.WriteLine(encryptPhrase);
                    break;
                case 2:
                    Console.WriteLine("Por favor, ingrese una frase:");
                    string DesencryptPhrase = CifradoCesar(Console.ReadLine(), false);
                    Console.WriteLine(DesencryptPhrase);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            break;
        case 2:
            int actionType2 = 0;
            Console.WriteLine("Cifrado Vigenere");
            Console.WriteLine("1. Encryptar");
            Console.WriteLine("2. Desencryptar");


            Console.WriteLine("Por favor, ingrese una opción:");
            actionType = Convert.ToInt32(Console.ReadLine());

            switch (actionType)
            {
                case 1:

                    Console.WriteLine("Ingresa la Frase");
                    string EncryptPhrase = EncryptadoVigenere(Console.ReadLine(), "KEY");
                    Console.WriteLine(EncryptPhrase);


                    break;
                case 2:
                    Console.WriteLine("Ingresa la Frase");
                    string result = DesCifradoVigenere(Console.ReadLine(), "KEY");
                    Console.WriteLine(result);
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            break;
        case 3:
            Console.WriteLine("-------SALIENDO--------");
            break;
        default:
            Console.WriteLine("Opción no válida");
            break;
    }


}

static string CifradoCesar(string text, bool type)
{
    string result = "";
    foreach(char c in text)
    {
        if (char.IsLetter(c))
        {
            int code = type == true ? (int)c + 3 : (int)c - 3;
            if (char.IsUpper(c))
            {
                if (code > (int)'Z')
                {

                    code -= 26;
                }
                else if (code < (int)'A')
                {
                    code += 26;
                }
                   
            }
            else if (char.IsLower(c))
            {
                if (code > (int)'z')
                {
                    code -= 26;
                }    
                else if (code < (int)'a')
                {
                    code += 26;
                }
                  
            }
            
            result += (char)code;

        }
        else
        {
            result += c;
        }

    }
    return result;
}

static string EncryptadoVigenere(string text, string key)
{
    text = text.ToUpper();
    key = key.ToUpper();
    string result = "";
    int keyIndex = 0;

    foreach (char c in text)
    {

        if (char.IsLetter(c))
        {
            int shift = key[keyIndex] - 'A';
            int encryptChar = c - shift;
            int encryptedChar = (c + shift - 'A') % 26 + 'A';


            result += (char)encryptedChar;
            keyIndex = (keyIndex + 1) % key.Length;


        }
        else
        {
            result += c;
        }
    }
    return result;
}


static string DesCifradoVigenere (string text, string key)
{
    text = text.ToUpper();
    key = key.ToUpper();
    string result = "";
    int keyIndex = 0;

    foreach (char c in text) { 
    
        if(char.IsLetter(c))
        {
            int shift = key[keyIndex] - 'A';
            int decryptChar = c - shift;

            if(decryptChar < 'A')
            {
                decryptChar += 26;

            }

            result += (char)decryptChar;
            keyIndex = (keyIndex + 1) % key.Length;


        }
        else
        {
            result += c;
        }
    }
    return result;
}

