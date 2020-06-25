using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MaruWPFDll.Element.Text;


namespace Capter4
{
    /// <summary>
    /// ScrollViewerTest.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ScrollViewerTest : Window
    {
        public ScrollViewerTest()
        {
            InitializeComponent();
            //ViewColorList()
            DependencyObjectClassHierarchy();
        }







        Type rootType = typeof(DependencyObject);
        TypeInfo rootTypeInfo = typeof(DependencyObject).GetTypeInfo();
        List<Type> classes = new List<Type>();
        Brush highlightBrush;


        protected void DependencyObjectClassHierarchy()
        {
            highlightBrush = new SolidColorBrush(Colors.Red);
            AddToClassList(typeof(Window));

            // Sort them alphabetically by name
            classes.Sort((t1, t2) =>
            {
                return String.Compare(t1.GetTypeInfo().Name, t2.GetTypeInfo().Name);
            });

            // Put all these sorted classes into a tree structure
            ClassAndSubclasses rootClass = new ClassAndSubclasses(rootType);
            AddToTree(rootClass, classes);

            // Display the tree using TextBlock's added to StackPanel
            Display(rootClass, 0);
        }


        void AddToClassList(Type sampleType)
        {
            Assembly assembly = sampleType.GetTypeInfo().Assembly;

            foreach (Type type in assembly.ExportedTypes)
            {
                TypeInfo typeInfo = type.GetTypeInfo();

                if (typeInfo.IsPublic && rootTypeInfo.IsAssignableFrom(typeInfo))
                    classes.Add(type);
            }
        }

        void AddToTree(ClassAndSubclasses parentClass, List<Type> classes)
        {
            foreach (Type type in classes)
            {
                Type baseType = type.GetTypeInfo().BaseType;

                if (baseType == parentClass.type)
                {
                    ClassAndSubclasses subClass = new ClassAndSubclasses(type);
                    parentClass.Subclasses.Add(subClass);
                    AddToTree(subClass, classes);
                }
            }
        }

        void Display(ClassAndSubclasses parentClass, int indent)
        {
            TypeInfo typeInfo = parentClass.type.GetTypeInfo();

            // Create TextBlock with type name
            TextBlock txtblk = new TextBlock();
            txtblk.Inlines.Add(new Run { Text = new string(' ', 8 * indent) });
            txtblk.Inlines.Add(new Run { Text = typeInfo.Name });

            // Indicate if the class is sealed
            if (typeInfo.IsSealed)
                txtblk.Inlines.Add(new Run
                {
                    Text = " (sealed)",
                    Foreground = highlightBrush
                });

            // Indicate if the class can't be instantiated
            IEnumerable<ConstructorInfo> constructorInfos = typeInfo.DeclaredConstructors;
            int publicConstructorCount = 0;

            foreach (ConstructorInfo constructorInfo in constructorInfos)
                if (constructorInfo.IsPublic)
                    publicConstructorCount += 1;

            if (publicConstructorCount == 0)
                txtblk.Inlines.Add(new Run
                {
                    Text = " (non-instantiable)",
                    Foreground = highlightBrush
                });

            // Add to the StackPanel
            stackPanel.Children.Add(txtblk);

            // Call this method recursively for all subclasses
            foreach (ClassAndSubclasses subclass in parentClass.Subclasses)
                Display(subclass, indent + 1);
        }



        protected string TextIntValueAddSpace(int pValue)
        {
            string sReturn = " ";
            for (int k = 0; k < pValue; k++)
            {
                sReturn += " ";
            }
            return sReturn;
        }







        protected void ViewColorList()
        {
            IEnumerable<PropertyInfo> properties = typeof(Colors).GetTypeInfo().DeclaredProperties;

            foreach (PropertyInfo property in properties)
            {
                Color clr = (Color)property.GetValue(null);
                /*
                TextBlock tbBlk = new TextBlock();
                tbBlk.Text = String.Format("{0} \x2014 {1:X2}-{2:X2}-{3:X2}-{4:X2}",
                                            property.Name, clr.A, clr.R, clr.G, clr.B);
                tbBlk.Foreground = new SolidColorBrush(clr);
                stackPanel.Children.Add(tbBlk);
                */
                OutlinedTextBlock outlinedTextBlock = new OutlinedTextBlock();
                outlinedTextBlock.Text = String.Format("{0} \x2014 {1:X2}-{2:X2}-{3:X2}-{4:X2}",
                                            property.Name, clr.A, clr.R, clr.G, clr.B);



                outlinedTextBlock.Fill = new SolidColorBrush(clr);
                outlinedTextBlock.FontSize = 30;
                outlinedTextBlock.StrokeThickness = 0.3;
                outlinedTextBlock.Stroke = new SolidColorBrush(Colors.White - clr);
                stackPanel.Children.Add(outlinedTextBlock);
            }
        }
    }













    public class ClassAndSubclasses
    {

        public Type type
        {
            protected set;
            get;
        }

        public List<ClassAndSubclasses> Subclasses
        {
            protected set;
            get;
        }



        public ClassAndSubclasses(Type parent)
        {
            type = parent;
            Subclasses = new List<ClassAndSubclasses>();
        }
    }
}
