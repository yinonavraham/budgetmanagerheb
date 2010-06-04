using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BudgetManager.Data;

namespace BudgetManager.GUI.WinForms.Utilities
{
    public class CommonMethods
    {
        public static void FillCategoriesTree(ref TreeView tree, Category root)
        {
            if (tree == null) return;
            tree.Nodes.Clear();
            TreeNode rootNode = new TreeNode(root.Name);
            rootNode.Tag = root;
            FillCategoriesTreeNode(ref rootNode, root);
            tree.Nodes.Add(rootNode);
        }


        public static void AddCategoriesTreeFirstLevel(ref TreeView tree, Category root)
        {
            if (tree == null) return;
            TreeNode rootNode = new TreeNode(root.Name);
            rootNode.Tag = root;
            FillCategoriesTreeNode(ref rootNode, root);
            tree.Nodes.Add(rootNode);
        }


        private static void FillCategoriesTreeNode(ref TreeNode node, Category category)
        {
            foreach (Category cat in category.SubCategories)
            {
                TreeNode newNode = new TreeNode(cat.Name);
                newNode.Tag = cat;
                FillCategoriesTreeNode(ref newNode, cat);
                node.Nodes.Add(newNode);
            }
        }
    }
}
