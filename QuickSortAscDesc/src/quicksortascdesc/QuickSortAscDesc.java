/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package quicksortascdesc;

import java.util.Arrays;
import java.util.Scanner;

/**
 *
 * @author josed
 */
public class QuickSortAscDesc {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        Scanner scanner = new Scanner(System.in);
        int[] arr = {64, 34, 25, 12, 22, 11, 10};
        
        System.out.println("Arreglo original: " + Arrays.toString(arr));
        System.out.println("¿Ordenar en forma ascendente (A) o descendente (D)?");
        String choice = scanner.nextLine().trim().toUpperCase();
        
        boolean ascending = choice.equals("A");
        if (choice.equals("A") || choice.equals("D")) {
            quickSort(arr, 0, arr.length - 1, ascending);
            System.out.println("Arreglo ordenado: " + Arrays.toString(arr));
        } else {
            System.out.println("Opción inválida. Use 'A' para ascendente o 'D' para descendente.");
        }
        
        scanner.close();
    }
    public static void quickSort(int[] arr, int low, int high, boolean ascending){
        if(low < high){
            int pi = partition(arr, low, high, ascending);
            quickSort(arr, low, pi - 1, ascending);
            quickSort(arr, pi + 1, high, ascending);
        }
    }
    private static int partition(int[] arr, int low, int high, boolean ascending) {
        int pivot = arr[high];
        int i = low - 1;
        for (int j = low; j < high; j++) {
            if (ascending) {
                if (arr[j] <= pivot) {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            } else {
                if (arr[j] >= pivot) {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        int temp = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp;
        return i + 1;
    }
    
    
}
