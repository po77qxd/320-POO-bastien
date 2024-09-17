using System;
using System.Data;
using System.Numerics;

namespace paraClub
{
    static class Config
    {
        public const int SCREEN_HEIGHT = 40;
        public const int SCREEN_WIDTH = 150;
    }

    class Plane
    {
        private int coordX = 0;
        private int coordY = 0;
        private string[] view =
            {
            @" _                         ",
            @"| \                        ",
            @"|  \       ______          ",
            @"--- \_____/  |_|_\____  |  ",
            @"  \_______ --------- __>-} ",
            @"        \_____|_____/   |  "
        };

        public int GetCoordX() { return coordX; }
        public void Update()
        {
            coordX++;
            coordY = 0;
            for (int i = 0; i < view.Length; i++)
            {
                Console.SetCursorPosition(coordX, coordY);
                Console.Write(view[i]);
                coordY++;
            }
        }
    }

    class Para
    {
        private int coordX;
        private int coordY = 0;
        //getter, setter private coordX, Y

        //enum etat (au sol, en vol, dans l'avion)
        enum ParaState
        {
            onGround,
            flying,
            inPlane
        }
        private ParaState state = ParaState.inPlane;
        //bool parachute ouvert
        bool parachuteOpen = false;
        private string[] withoutParachute =
            {
                @"     ",
                @"     ",
                @"     ",
                @"  o  ",
                @" /░\ ",
                @" / \ ",
            };
        private string[] withParachute =
{
         @" ___ ",
         @"/|||\",
         @"\   /",
         @" \o/ ",
         @"  ░  ",
         @" / \ ",
     };
        // Constructeur (pas de parametre)
        public Para()
        {

        }
        // methode: update() -> deplace puis dessine le para (si en vol)
        public void Update()
        {
            if (state == ParaState.flying) {

                if (coordY < 20)//20 = moitie de la console
                {
                    for (int i = 0; i < withoutParachute.Length; i++)
                    {
                        Console.SetCursorPosition(coordX, i + coordY);
                        Console.Write(withoutParachute[i]);
                    }
                    coordY += 3;
                }
                else if (coordY < 34)//34 car le parachutiste fait 6 de haut
                {
                    for (int i = 0; i < withParachute.Length; i++)
                    {
                        Console.SetCursorPosition(coordX, i + coordY);
                        Console.Write(withParachute[i]);
                    }
                    coordY++;
                }
                else
                {
                    for (int i = 0; i < withoutParachute.Length; i++)
                    {
                        Console.SetCursorPosition(coordX, i + coordY);
                        Console.Write(withoutParachute[i]);
                    }
                }
            }
        }
        // methode: jump() -> doit demander la position a l'avion puis change l'etat "En vol"
        //recoit la coordX de depart
        public void Jump(int planeCoordX)
        {
            coordX = planeCoordX;
            state = ParaState.flying;
        }
        // methode: isDansAvion() -> true si etat = dans l'avion
        //rend true si dans avion
        public bool IsInPlane()
        {
            return (state == ParaState.inPlane);
        }
    }

    class GroupOfPara
    {
        private List<Para> parachutistes;


        public GroupOfPara() {
            this.AddPara();
        }
        private void AddPara()
        {
            parachutistes = new List<Para>();
            for (int numPar = 0; numPar < 10; numPar++)
            {
                parachutistes.Add(new Para());
            }
        }
         //recoit la coordX de lavion
        public void ParaFall(int planeCoordX)
        { 
            foreach (Para jumper in parachutistes)
            {
                if (jumper.IsInPlane())
                {
                    jumper.Jump(planeCoordX);
                    break;
                }
            }
        }
        public void Update()
        {
            foreach (Para jumper in parachutistes)
            {
                jumper.Update();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool isFinished = false;
            Console.WindowWidth = Config.SCREEN_WIDTH;
            Console.WindowHeight = Config.SCREEN_HEIGHT;
            Plane plane = new Plane();
            GroupOfPara groupOfPara = new GroupOfPara();
            while (!isFinished)
            {
                if (Console.KeyAvailable) // L'utilisateur a pressé une touche
                {
                    var keyPressed = Console.ReadKey(true);
                    switch (keyPressed.Key)
                    {
                        case ConsoleKey.Escape:
                            isFinished = true;
                            break;
                        case ConsoleKey.Spacebar:
                            int planeCoordX = Console.CursorLeft;
                            groupOfPara.ParaFall(plane.GetCoordX());
                            break;
                    }
                }
                Console.Clear();
                plane.Update();
                groupOfPara.Update();
                // Modifier ce que l'on *voit*

                // Temporiser
                Thread.Sleep(250);

            }
        }
    }
}
