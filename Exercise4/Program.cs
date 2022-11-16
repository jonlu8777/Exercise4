
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;

namespace Exercise4
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            /*1.​​​​​​​​​​​​​​​​Hur​​fungerar​​​stacken​​​och​​​heapen​?​​Förklara​​gärna​​med​​exempel​​eller​​skiss​​på​​dessgrundläggande​​funktion
             * SVAR: Stacken utför metoder och anrop i tur och ordning. Värdetyper som deklareras utanför objekt hamnar på heapen, tex. i statiska metoder.
             * De rensas automatiskt efter att de exekverats. 
             * Referenstyper hamnar på heapen, men de sparas även på heapen i pointers, som pekar på var i heapen de lagras.
             * Garbage collectorn resnar ut värdetyper på heapen när de saknar referens.
             * Alla värden i heapen är tillgänglia att nås utan hänsyn till viss ordning.                      
             * 
             * 2.​​​​​​​​​​​​​​​​Vad​​är​​​Value​​Types​​​repsektive​​​Reference​​Types​​​och​​vad​​skiljer​​dem​​åt?
             * Värdetyper är t.ex. bool, int, decimal, short... sparas i stacken, 
             * Referenstyper är objekt, klasser, interface, delegater, stringar och sparas i heapen.
             * Referenstyperna sparas även som sagt i heapen som pointers. 
             * Värdetyper som int, kan sparas i heapen, men då som attribut/properties/fält i t.ex. en klass.
             * 
             * 3.Följande​​metoder​​(​se​​bild​​nedan​)​​genererar​​olika​​svar.​​Den​​första​​returnerar​​3,​​denandra​​returnerar​​4,​​varför?
             *  För att i den första bilden sparas värdetypen int på heapen. Men i den andra så sparas int värdet som referenstyp,
             *  och då x och y är objekt(två olika pekare i stacken), gör att när  x=y (pekar på samma objekt i heapen);  
             *  då blir y.MyValue = 4; samma värde(minnesposition) som x.MyValue i heapen. 
             *  
             */


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            bool doThis = true;
            while (doThis)
            {
                /*1.​​​​​​​​​​​​​​​​Skriv​​klart​​implementationen​​av​​​ExamineList-metoden​​​så​​att​​undersökningen​​blirgenomförbar.
                 * 2.​​​​​​​​​​​​​​​​När​​ökar​​listans​​kapacitet?​​(Alltså​​den​​underliggande​​arrayens​​storlek)
                 * Svar: När Capacity är full, initalt 0, vid första elementet Adderas 4 platser, sen vid 5:e elementet skapar 8 platser... 
                 * 3.​​​​​​​​​​​​​​​​Med​​hur​​mycket​​ökar​​kapaciteten?
                 * Svar: 0, 4, 8, 16, 64, 128... dvs dubbleras.
                 * 4.​​​​​​​​​​​​​​​​Varför​​ökar​​inte​​listans​​kapacitet​​i​​samma​​takt​​som​​element​​läggs​​till?
                 * Svar: Minnet ökar i 4 
                 * 5.​​​​​​​​​​​​​​​​Minskar​​kapaciteten​​när​​element​​tas​​bort​​ur​​listan?
                 * Svar: Nej, men man kan använda metoden TrimExcess för att skala ned storleken.  
                 * 6.​​​​​​​​​​​​​​​​När​​är​​det​​då​​fördelaktigt​​att​​använda ​​en ​​egendefinierad ​​​array ​​​istället​​för​​en​​lista?
                 * Svar: Om antalet platser man kommer behöva inte förändras samt att de är av samma typ.    
                 */
                Console.WriteLine("Capacity:" + theList.Capacity); //Capacity ökar:
                Console.WriteLine("Count:" + theList.Count);
                Console.WriteLine("+");                           //dvs. 0, 4 , 8 , 16, 32, 64, 128....   
                Console.WriteLine("-");
                Console.WriteLine("q. Exit");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add((value));
                        foreach (string item in theList)
                        {
                            Console.Write(item + " ");

                        }
                        break;
                    case '-':
                        theList.Remove((value));
                        foreach (string item in theList)
                        {
                            Console.Write((item + " "));
                        }
                        Console.WriteLine();

                        break;
                    case 'q':
                        doThis = false;
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */


            Queue<string> theQueue = new Queue<string>();
            bool doThis = true;
            while (doThis)
            {


                Console.WriteLine("+:Simulera Kön till ICA");
                Console.WriteLine("-: Print Que");
                Console.WriteLine("q. Quit");

                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {

                    case '+':

                        Console.WriteLine("a. Ica öppnar och kön till kassan är tom");
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("b. kalle ställer sig i kön");
                        theQueue.Enqueue("b. kalle ställer sig i kön");
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("c. Greta ställer sig i kön");
                        theQueue.Enqueue("c. Greta ställer sig i kön");
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("d. Kalle blir expiderad och lämnar kön");
                        theQueue.Dequeue();
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("e. Stina ställer sig i kön");
                        theQueue.Enqueue("e. Stina ställer sig i kön");
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("f. Greta blir expiderad och lämnar kön");
                        theQueue.Dequeue();
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        Console.WriteLine("g. Olle ställer sig i kön");
                        theQueue.Enqueue("g. Olle ställer sig i kön");
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        break;

                    case '-':
                        foreach (string a in theQueue)
                        {
                            Console.WriteLine(a);
                        }
                        Console.WriteLine($"Det finns nu {theQueue.Count} köplatser");
                        Console.WriteLine("----------------------------------------");

                        break;

                    default: break;
                    case 'q':
                        doThis = false;
                        break;


                }




            }

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            
             1.​​​​​​​​​​​​​​​​Simulera​​ännu​​en​​gång​​ICA-kön​​på​​papper.​​Denna​​gång​​med​​en​​​stack​.​​Varför​​är​​detinte​​så​​smart​​att​​använda​​en​​​stack​​​i​​det​​här​​fallet?
             Svar: För att den/de som är First In d.v.s. kalle blir expiderad sist, och risken finns att han aldrig blir expiderad. 
         
             
             
             */
            bool doThis = true;
            while (doThis)
            {
                Console.WriteLine();
                Stack stack = new Stack();
                Console.WriteLine("-: Exit");
                Console.WriteLine("Input and Print Reversed Text");
                string input = Console.ReadLine();
                char c = input[0];
                string value = input.Substring(1);

                switch (c)
                {
                    case '+':
                        Console.WriteLine("Enter text: ");
                        var str = Console.ReadLine();

                        foreach (char cha in str)
                        {
                            stack.Push(cha);
                        }

                        foreach (char cha in str)
                        {

                            Console.Write(stack.Pop());
                        }

                        break;

                    case '-':

                        doThis = false;
                        break;


                }
            }
        


    
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            bool doThis = true;
            while (doThis)
            {
           
                Stack stack = new Stack();
                Queue que = new Queue();

                string str = "([{}]({}))";
                //string str = "List<int> list = new List<int>() { 1, 2, 3, 4 }";                
                // string str = ")[()]";
                Console.WriteLine(str);

                int firstCharVinge = 0;
                int stringCounter = -1;
                int stringLenght = str.Length - 1;
                char stackPeek = 'E';
                int badTextWarning = 0;

                foreach (char c in str)         //Fyll en kölista med text! bara för att jag kan... 
                {
                    que.Enqueue(c);
                }

                var paranteserSymboler = new Dictionary<char, char>() //sparar och strukturerar giltiga värdepar (måsvingar..)
                {                                                     //Underlättar enormt mycket
                  { '{','}'},
                  { '(',')' },
                  { '[',']' },
                };
                            foreach (char c in que)       //för varje char c i kön loopa!
                            {
                                stringCounter++;
                                Console.WriteLine($"{stringCounter}/{stringLenght}");

                                if (firstCharVinge > 0)  // test för att inte läsa en empty stack!!
                                {
                                    stackPeek = (char)stack.Peek();     // lagrar tillfälligt för att se ingångsvärdet per 'char'
                                    Console.WriteLine($"STACK AT ENTRY: {stackPeek}");
                                }


                                for (int i = 0; i < paranteserSymboler.Count; i++) //För alla symbolpar, kolla igenom alla ÖPPNANDE Key ValuePair
                                {
                                    //Börjar kolla om den första symbolen && vid symbol vid tom stack, ÄR symbolen STÄNGD => inte välformad!
                                    if (c.Equals(paranteserSymboler.ElementAt(i).Value) && firstCharVinge == 0)
                                    {
                                        badTextWarning++; //Vi har en icke välformad text.
                                    }

                                    if (c.Equals(paranteserSymboler.ElementAt(i).Key)) //Testa är c en giltig char (Key) i kösträngen
                                    {
                                        stack.Push(paranteserSymboler.ElementAt(i).Value); //Lägg den spegelvända symbolen (Value) på stacken
                                        firstCharVinge = 1;                             //Bocka av att vi åt minstonde har lagt 1 värde på stacken
                                    }


                                    if (c.Equals(paranteserSymboler.ElementAt(i).Value)) //Här testar vi STÄNGDA symboler i kön
                                    {
                                        if (stackPeek.Equals(c))                         //Finns symbolen i stacken?
                                            stack.Pop();                                 //Då raderar vi den från stacken!
                                        else Console.WriteLine($" {badTextWarning++}: texten är inte välformad"); //Fanns den inte i stacken!?
                                                                                                                  //Då har vi ett icke välformat mönster!

                                        if (stack.Count == 0)
                                        {
                                            firstCharVinge = 0;
                                        }
                                    }
                                }
                                if (firstCharVinge > 0) //om stacken är inte tom, så vågar vi kalla på metoden: stack.Peek();
                                    Console.WriteLine($"Stack:{stack.Peek()} Que: {c}"); //SKRIVER UT värdet i stacken och i kön.

                            }
                            //Vi är klara med loopanden!
                            if (stringCounter == stringLenght) //Vi har nu gått igenom hela strängen och räknat färdigt! 
                            {
                                Console.WriteLine("---------------------------");
                                Console.WriteLine("---------------------------");
                                Console.WriteLine("Test Avslutad");
                                Console.WriteLine($"Antal fel: {badTextWarning}");
                                if (badTextWarning == 0)                        //kollla så att vi inte har några fel på värdena!
                                    Console.WriteLine("APPROVED TEXT!");
                                Console.WriteLine("---------------------------");
                                if (badTextWarning > 0)                         //skriv ut INVALID om vi har felmeddelanden!
                                    Console.WriteLine("TEXT IS INVALID!");
                                Console.WriteLine("---------------------------");
                            }
                            doThis = false; //återgå till menu
                            
                        }
                      
                        doThis = false;
                      
                }
            }
        }
    



