public class Test{
    
    //メイン関数
    public static void Main(){
        int val = 5;
        System.Console.WriteLine(calc(val));
    }
    
    //算出用関数
    public static int calc(int val){
        int ret_val = 0;
        ret_val = val * 2;
        return ret_val;
    }
}