/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package fibonacci;

import java.util.Scanner;

/**
 *
 * @author josed
 */
public class Fibonacci {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner scanner = new Scanner(System.in);
        System.out.print("Ingrese el número de elementos para la serie Fibonacci: ");
        int n = scanner.nextInt();
        Fibonacci(n);
        scanner.close();
    }
    
    private static void Fibonacci (int n){
    
        int first = 0, second = 1;
        
        System.out.print("Serie Fibonacci de " + n + " números: ");
        
        for (int i = 1; i <= n; i++) {
            System.out.print(first + " ");
            int next = first + second;
            first = second;
            second = next;
        }
    }
}
