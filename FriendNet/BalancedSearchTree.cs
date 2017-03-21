using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FriendNet
{
    public class BalancedSearchTree 
    {
        //private int data=int.MinValue;  //结点数据
        private int[] addStatue = new int[3];
        private BalanceStatue balFactor; //结点平衡因子。只有0，1，-1态
        //private int leftHigher = 1;
        //private int equalHigh = 0;
        //private int rightHigher = -1;
        private BalancedSearchTree LChild, RChild;
        private Boolean head = true;
        private Boolean taller;
    
        private BalancedSearchTree Parent;  //用于创建叶子时记录双亲。
        private Boolean leftChildRecord; //true创建左孩子，false创建右孩子
        private int[] isIn = new int[2];
        //private int times;
        //public int Times
        //{
        //    get
        //    {
        //        return times;

        //    }
        //}
        private enum BalanceStatue:int
        {
            leftHigher=1,
            rightHigher=-1,
            equalHigh=0
        }
        public BalancedSearchTree(int[] exampleData) 
        {
            this.addStatue= exampleData;
            this.balFactor = 0;
            this.LChild = null;
            this.RChild = null;
        }
    
        public Boolean insertTree(BalancedSearchTree T, int[] keyData) 
        {

            //创建树根######################################################################################
            if (this.head) 
            { 
                T.addStatue= keyData;
                this.taller = true;
                this.head = false;
            } 
        
            //遍历到叶子的时候#############################################################################
            else if(T==null) 
            {
                if (leftChildRecord) 
                {  //上次记录是左孩子的话
                    Parent.LChild = new BalancedSearchTree(keyData);
                    Parent.LChild.Parent = Parent;
                }
                else 
                { //否即是右孩子
                    Parent.RChild = new BalancedSearchTree(keyData);
                    Parent.RChild.Parent = Parent;
                }
                this.taller = true;
            }
        
            //树枝的情况##################################################################################
            else
            {
                if (T.addStatue[0].Equals(keyData))
                {// 已有就不再录入了
                    this.taller = false;
                    return false;
                }
                else if (keyData[0] < T.addStatue[0])
                {
                //将从T的左子树进行搜索，先进行记录
                    Parent = T;
                    leftChildRecord = true;
                    if (insertTree(T.LChild, keyData) == false) 
                    {
                    //没有插入
                        return false;
                    }
                    else if(this.taller)
                    {
                        switch (T.balFactor)
                        {//检查T的平衡度
                            case BalanceStatue.leftHigher://原来的左子树就已经比右子树高，需左平衡
                                LeftBalance(T);
                                this.taller = false;
                                break;
                            case BalanceStatue.equalHigh://原来等高
                                T.balFactor = BalanceStatue.leftHigher; //现在左子树增高了一层
                                this.taller = true;
                                break;
                            case BalanceStatue.rightHigher://原来右子树比左子树高
                                T.balFactor = BalanceStatue.equalHigh;//现在等高
                                this.taller = false;
                                break;
                        }   
                    }
                }
                else
                {// 即 keyData.compareTo(T.data) >  0，与上边情况对称，不再作注释。
                    Parent = T;
                    leftChildRecord = false;
                    if (insertTree(T.RChild, keyData) == false) 
                    {
                        return false;
                    }
                    else if (this.taller) 
                    {
                        switch (T.balFactor) 
                        {
                            case BalanceStatue.leftHigher:
                                T.balFactor = BalanceStatue.equalHigh;
                                this.taller = false;
                                break;
                            case BalanceStatue.equalHigh:
                                T.balFactor = BalanceStatue.rightHigher;
                                this.taller = true;
                                break;
                            case BalanceStatue.rightHigher:
                                RightBalance(T);
                                this.taller = false;
                                break;
                        }
                    }
                }
            }
            return true;
    }
    
        //右旋操作
        private void RightRotate (BalancedSearchTree T) 
        {
        	BalancedSearchTree LeftKid;
            int[] t;                                          //                   T                  LeftKid
            LeftKid = T.LChild;                              //                /   \                /   \
            T.LChild = LeftKid.LChild;                          //        LeftKid   TR            LL     T
            LeftKid.LChild = LeftKid.RChild;             //                 /    \         =>           /  \ 
            LeftKid.RChild = T.RChild;                        //          LL      LR                   LR   TR
            T.RChild = LeftKid;                        //                                                                                                           
            t = T.addStatue;
            T.addStatue = LeftKid.addStatue;
            LeftKid.addStatue = t;
        }
    
        //左旋操作,与右旋对称，不再画图了……
        private void LeftRotate (BalancedSearchTree T) 
    {
    	BalancedSearchTree RightKid;
        int[] t;
        RightKid = T.RChild;
        T.RChild = RightKid.RChild;
        RightKid.RChild = RightKid.LChild;
        RightKid.LChild = T.LChild;
        T.LChild =  RightKid;
        t = T.addStatue; T.addStatue = RightKid.addStatue; RightKid.addStatue = t;
    }
    
        // 左平衡
        private void LeftBalance ( BalancedSearchTree T) 
    {
    	BalancedSearchTree LeftSubTree, LChildRightSubTree;
        LeftSubTree = T.LChild;
        
        switch (LeftSubTree.balFactor) 
        {
            case BalanceStatue.leftHigher: // T左孩子的左子树高了，作右旋处理
                T.balFactor = BalanceStatue.equalHigh;
                LeftSubTree.balFactor = BalanceStatue.equalHigh;
                RightRotate(T);
                break;
            
            case BalanceStatue.rightHigher://T左孩子的右子树高了，作双旋处理（因为每次都会及时处理掉，所以这是最底端的情况）
                LChildRightSubTree = LeftSubTree.RChild;
            
            switch (LChildRightSubTree.balFactor) 
            {
                case BalanceStatue.leftHigher:// T左孩子的右孩子的左子树高了
                    T.balFactor = BalanceStatue.rightHigher;
                    LeftSubTree.balFactor = BalanceStatue.equalHigh;
                    break;
                
                case BalanceStatue.equalHigh:
                    T.balFactor  = BalanceStatue.equalHigh;
                    LeftSubTree.balFactor = BalanceStatue.equalHigh;
                    break;
                
                case BalanceStatue.rightHigher:
                    T.balFactor = BalanceStatue.equalHigh;
                    LeftSubTree.balFactor = BalanceStatue.leftHigher;
                    break;
            }

            LChildRightSubTree.balFactor = BalanceStatue.equalHigh;   //平衡过后T左孩子的右孩子恢复平衡
            LeftRotate(T.LChild); //继续向上平衡
            RightRotate(T);////继续向上平衡
            break;
        }
    }
    
        // 右平衡，与左平衡对称，不再累述。
        private void RightBalance (BalancedSearchTree T)
    { 
    	BalancedSearchTree RightSubTree, RChildLeftSubTree;
        RightSubTree = T.RChild;
        switch (RightSubTree.balFactor) 
        {
            case BalanceStatue.rightHigher: 
                T.balFactor = BalanceStatue.equalHigh;
                RightSubTree.balFactor = BalanceStatue.equalHigh;
                LeftRotate(T);
                break;
            
            case BalanceStatue.leftHigher:
                RChildLeftSubTree = RightSubTree.LChild;
                switch (RChildLeftSubTree.balFactor) 
                {
                    case BalanceStatue.rightHigher: 
                        T.balFactor = BalanceStatue.leftHigher;
                        RightSubTree.balFactor = BalanceStatue.equalHigh;
                        break;
                    case BalanceStatue.equalHigh:
                        T.balFactor  = BalanceStatue.equalHigh;
                        RightSubTree.balFactor = BalanceStatue.equalHigh;
                        break;
                    case BalanceStatue.leftHigher:
                        T.balFactor = BalanceStatue.equalHigh;
                        RightSubTree.balFactor = BalanceStatue.rightHigher;
                        break;
            }
            RChildLeftSubTree.balFactor = BalanceStatue.equalHigh;
            RightRotate(T.RChild);
            LeftRotate(T);
            break;
        }
    }
    
    
        //中序遍历树
        public void middle(BalancedSearchTree T,StreamWriter sw)
        {
            if (T == null)
            {
                return;
            }
            middle(T.LChild,sw);
            //Console.WriteLine(T.addStatue[0]);
            sw.WriteLine(T.addStatue[0] + "饕" + T.addStatue[1] + "饕" + T.addStatue[2]);
            middle(T.RChild,sw);
        }

        public int[] Search(BalancedSearchTree T,int data)
        {
            
            if (T == null)
            {
                isIn = new int[]{data,0,1};
                return new int[]{data,0,1};
            }
            else if (data == T.addStatue[0]&&T.addStatue[1]==1)
            {
                isIn = new int[] {T.addStatue[0], 1, T.addStatue[2] };
                ++T.addStatue[2];
                return new int[]{T.addStatue[0],1,T.addStatue[2]};
            }
            else if (data == T.addStatue[0] && T.addStatue[1] == 0)
            {
                isIn = new int[] { T.addStatue[0], 0, T.addStatue[2] };
                ++T.addStatue[2];
                return new int[] { T.addStatue[0], 0, T.addStatue[2] };
            }
            else if (data < T.addStatue[0])
            {
                isIn=T.Search(T.LChild, data);
            }
            else if (data > T.addStatue[0])
            {
                isIn=T.Search(T.RChild, data);
            }
            if (isIn[1]==1)
            {
                return new int[] { data, isIn[1], isIn[2] };
            }
            else
            {
                return new int[] { data, 0, 1 };
            }
        }
    
    
    
    }
    
}

