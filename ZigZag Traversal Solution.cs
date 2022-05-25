/**
 * Instruction: 
     Please create a main method that calls the ZigzagLevelOrder method with the appropriate parameter
      
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class nodoNivel{
    public TreeNode node;
    public int nivel;
}

public class Solution {
    public void ReverseIt(IList<int> lista){
        int max = lista.Count/2;
        for (int i=0; i<max; i++){
            int t = lista[i];
            lista[i] = lista[lista.Count-1-i];
            lista[lista.Count-1-i] = t;
        }        
    }
    
    
    public void Helper(TreeNode root, IList<IList<int>> result){
        Queue<nodoNivel> q = new Queue<nodoNivel>();
        IList<int> lista = new List<int>();
        int actualLevel = 0;
        string direction = "L2R";
        
        nodoNivel objeto =  new nodoNivel();   
        objeto.node = root; objeto.nivel = 0;
        q.Enqueue(objeto);
        while(q.Count > 0)
        {
            nodoNivel current = q.Dequeue();
            if(current.node != null){
                if (current.nivel != actualLevel){
                    actualLevel++;
                    if ((direction == "R2L") && (lista.Count > 0)) {
                        ReverseIt(lista);
                    }
                    result.Add(lista);
                    lista = new List<int>();
                    lista.Add(current.node.val);
                    direction = (direction == "R2L")?"L2R":"R2L";
                }
                else{
                    lista.Add(current.node.val);                                        
                }
                    

                nodoNivel objetoL =  new nodoNivel();   
                objetoL.node = current.node.left; objetoL.nivel = current.nivel + 1;

                nodoNivel objetoR =  new nodoNivel();   
                objetoR.node = current.node.right; objetoR.nivel = current.nivel + 1;
                
                q.Enqueue(objetoL);                
                q.Enqueue(objetoR);                                        
                
                Console.WriteLine(current.node.val + ", " + current.nivel + "," + direction);
            }
        }
        if (direction == "R2L")
            ReverseIt(lista);
        result.Add(lista);
    }
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();  
        if (root != null){
            Helper(root, result);
        }
        return result;
    }
}