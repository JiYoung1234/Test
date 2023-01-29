using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpstudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //1장

            /*System.Console.WriteLine("hello world");
            System.Console.WriteLine("제 이름은 박지영입니다.");
            System.Console.WriteLine("24입니다.");
            System.Console.WriteLine("처음으로 제용돈으로 공부를 합니다.");
            System.Console.WriteLine("인천 가좌동에 삽니다.");*/
            System.Console.WriteLine("쉬는 날에는 십자수를 합니다.");
            System.Console.WriteLine("언젠가는 게임을 개발하고 싶습니다.");
            System.Console.WriteLine("모바일 게임을 많이 합니다.");
            System.Console.WriteLine("학교는 통학합니다.");
            System.Console.WriteLine("심심할때 프라모델을 조립니다.");

            //살려줘
            //write writeLine 을 배웠다

            //write writeLine 번갈아 쓰기
            System.Console.WriteLine("1");
            System.Console.Write("2");
            System.Console.WriteLine("3");
            System.Console.Write("4");
            System.Console.WriteLine("5"); 
            System.Console.Write("6");
            System.Console.WriteLine("7");
            System.Console.Write("8");
            System.Console.WriteLine("9");
            System.Console.Write("10");

            System.Console.WriteLine("\n");


            //데이터형 - string
            string myName;
            myName = "Jyoung";
            System.Console.WriteLine(myName);

            //string adress;
            //adress = "인천";
            //System.Console.WriteLine(adress);

            //string age;
            //age = "24";
            //System.Console.WriteLine(age);

            string hobby;
            hobby = "십자수";
            System.Console.WriteLine(hobby);

            System.Console.WriteLine("\n");

            //ReadLine();
            //이름
            string name;
            System.Console.Write("이름을 입력해 주세요 : ");
            name = System.Console.ReadLine();

            System.Console.Write("당신의 이름은 : ");
            System.Console.WriteLine(name);

            //나이
            string age;
            System.Console.Write("당신의 나이 : ");
            age = System.Console.ReadLine();

            //주소
            string adress;
            System.Console.Write("주소 : ");
            adress = System.Console.ReadLine();

            string gender;
            System.Console.Write("성별 : ");
            gender = System.Console.ReadLine();

            System.Console.Write($"당신의 이름은 {name} 이고, 당신의 나이는 {age} 입니다.");
            System.Console.WriteLine("당신의 이름은 {0} 이고, 당신의 나이는 {1} 입니다", name, age);

            //2장

            int myage = 3;
            string myname = "jy";
            float today = 1.29f;

            System.Console.WriteLine(int.MaxValue);
            System.Console.WriteLine(int.MinValue);

            int myNumber = 2147423647;
            System.Console.WriteLine(myNumber + 1);

            System.Console.WriteLine("강아지 \"하루\" 이쁘다");
            string aaa = myage + myname;
            System.Console.WriteLine(aaa);

            string ss = null;

            string myAge;
            System.Console.Write("나이를 입력하세요 : ");
            myAge = System.Console.ReadLine();
            int myAgeNumber = Convert.ToInt32(myAge);
            string nowAge = (myAgeNumber + 3).ToString();

            /*
            string birthyear;
            System.Console.Write("태어난 년도를 입력하세요 : ");
            birthyear = System.Console.ReadLine();
            int myAgenumber = Convert.ToInt32(birthyear);
            string nowage = (2023 - myAgenumber).ToString();
            System.Console.Write(nowage);
            */

            System.Console.WriteLine(@"
       *
      ***
     *****
    *******
   *********");

            //1. 변수형 종류 주석으로 작성후, 각 변수형들의 최대값 최소값을 구하시오
            //int double float char
            System.Console.WriteLine(int.MaxValue);
            System.Console.WriteLine(int.MinValue);

            System.Console.WriteLine(double.MaxValue);
            System.Console.WriteLine(double.MinValue);

            System.Console.WriteLine(float.MaxValue);
            System.Console.WriteLine(float.MinValue);

            System.Console.WriteLine(char.MaxValue);
            System.Console.WriteLine(char.MinValue);

            //2. string으로 이름 나이 입력받고, 출력하기
            string MYname,MYage;
            System.Console.WriteLine("당신의 이름 : ");
            MYname= System.Console.ReadLine();
            //System.Console.WriteLine("당신의 나이 : ");
            //MYage = System.Console.ReadLine();

            
             string birthyear;
            System.Console.Write("태어난 년도를 입력하세요 : ");
            birthyear = System.Console.ReadLine();
            int myAgenumber = Convert.ToInt32(birthyear);
            string nowage = (2023 - myAgenumber).ToString();
            System.Console.WriteLine(nowage);
             

            System.Console.WriteLine("당신의 이름은 {0}이고, 나이는 {1}살입니다.", MYname, nowage);
            //System.Console.WriteLine("당신의 이름은 {0}이고, 나이는 {1}입니다.", MYname, MYage);


            //3. @사용해서 별 그리기
            System.Console.WriteLine(@"
                                  *
                                 * *
                            ***** *******
                              *       *
                             *  * * *  *
                            *           *") ;

            //4. int값을 float로 캐스팅하기
            // 3.12를 int 값으로 캐스팅하기
            int a = 3;
            float ab = (float)a;

            System.Console.WriteLine("\n");


            double b = 3.12;
            float c = 3.14f;
            int dc = Convert.ToInt32(b);
            System.Console.WriteLine(dc);

            int cd = Convert.ToInt32(c);
            System.Console.WriteLine(cd);

            //이름을 입력받고
            //입력받은 이름의 길이를 숫자로 바꾸고
            //받은 숫자를 출력한다.

            string NAME;
            System.Console.WriteLine("당신의 이름은 : ");
            NAME=System.Console.ReadLine();

            int abc = NAME.Length;

            System.Console.WriteLine(abc);

            //3장
            string asd = "박지영";
            //값을 가져올껀데 int, string, char 형인지 모를때
            var qqq = "박지영";
            var www = 3;
            var eee = 3.14f;

            //배열
            int[] iii = new int[3];
            int kk = 1;
            int kkk = 4;
            int kkkk = 9;

            int[] lll = new int[4] { 89, 2, 3, 4 };
            System.Console.WriteLine(lll[0]);

            string[] lang = new string[3] { "c", "c#", "c++" };
            long[] lolo = new long[1] { 2 };

            //kkk -> 89, 2, 3, 4
            //lang -> c, c++, c#

            //int형 배열 5칸짜리 5개
            int[] ooo = new int[5] { 0, 1, 2, 3, 4 };
            //string형 배열 5칸자리 5개
            string[] ppp = new string[5] { "q", "w", "e", "r", "t" };

            int[] laterArray;

            System.Console.WriteLine("배열의 크기는? ");
            string ArraySize;
            ArraySize = System.Console.ReadLine();

            laterArray = new int[Convert.ToInt32(ArraySize)];

            string[] langs = new string[3];
            langs[0] = "c";
            langs[1] = "c++";
            langs[2] = "c#";
            System.Console.Write($"0번 값은 {langs[0]}입니다.");
            langs[0] = "집";
            System.Console.WriteLine($"0번 값은 {langs[0]}입니다.");

            //식당에 음식이 떡볶이, 김밥, 라면, 라뽁이가 있다.
            //이중에 숫자를 입력받으면
            //입력받은 값은 비어있게 된다.

            //최초 음식들과
            //숫자를 입력받았을때 음식을 출력하고
            //비어있게 되었다라는 결과값도 출력하라

            string[] food = new string[4] { "떡볶이", "김밥", "라면", "라뽁이" };
            System.Console.WriteLine("원하는 음식 숫자? ");
            string foodnumber;
            foodnumber = System.Console.ReadLine();
            
        }
    }
}
