using System;

namespace _0814_EventHandler
{
    //대리자 Delegate 선언... 대리자란 메소드에 대한 참조. 대리자에 메소드의 주소를 할당한 후 대리자를 호출하면 대리자가 메소드를 호출해 준다.
    //비서 자리를 만듦(int, string과 마찬가지로 그릇에 해당)
    delegate void EventHandler(string message);
    
    class MyNotifier
    {
        //만들어 둔 비서 자리에 비서를 고용(인스턴스 선언)
        public event EventHandler SomethingHappened;
        //이벤트가 일어나면 수행할 메소드 생성
        //사장이 할 일
        public void DoSomething(int number)
        {
            int temp = number % 10;
            if (temp != 0 && temp % 3 == 0)
                SomethingHappened(String.Format("{0} : 짝", number));
        }
    }
    class Program
    {
        //비서가 전달해 줄 사항
        static public void MyHandler(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            
            MyNotifier notifier = new MyNotifier();
            //이벤트가 발생하면 비서를 호출함->비서가 전달 사항 가져 옴
            notifier.SomethingHappened += new EventHandler(MyHandler);
            //이벤트가 함발생하면 비서를 호출해서 비서가 전달사항을 가져오고, 사장이 전달사항을 받아서 처리
            for (int i = 1; i < 30; i++)
                notifier.DoSomething(i);
        }
    }
}
