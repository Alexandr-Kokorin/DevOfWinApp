using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Lab4CS
{
    public class Graphic
    {
        public Viewport3D myViewport3D;
        public float radius = 20;
        public ModelVisual3D cube;
        public Point3D point;
        private int len = 40;
        private IFunction function;

        public Graphic(int func)
        {
            point = new Point3D(1, 1, 1);
            switch (func)
            {
                case 1: function = new Func1(); break;
                case 2: function = new Func2(); break;
                case 3: function = new Func3(); break;
                case 4: function = new Func4(); break;
            }

            myViewport3D = new Viewport3D();
            Model3DGroup myModel3DGroup = new Model3DGroup();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            myViewport3D.Camera = getPerspectiveCamera();
            myModel3DGroup.Children.Add(getDirectionalLight());

            Point3DCollection PositionCollection = createVertexPositions();

            for (int y = 1; y < len; y++)
            {
                for (int x = 1; x < len; x++)
                {
                    Point3D[] myPoints = new Point3D[] {PositionCollection[y * len + x - len],
                        PositionCollection[y * len + x - 1], PositionCollection[y * len + x - len - 1]};
                    myModel3DGroup.Children.Add(getTriangle(myPoints, 1));

                    myPoints = new Point3D[] {PositionCollection[y * len + x - len],
                        PositionCollection[y * len + x], PositionCollection[y * len + x - 1]};
                    myModel3DGroup.Children.Add(getTriangle(myPoints, 2));
                }
            }

            Point3D[] points = new Point3D[] {new Point3D(-0.02,-0.02, 10), new Point3D(0.02, -0.02, 10),
            new Point3D(-0.02, 0.02, 10), new Point3D(0.02, 0.02, 10), new Point3D(-0.02,-0.02, -10),
            new Point3D(0.02, -0.02, -10), new Point3D(-0.02, 0.02, -10), new Point3D(0.02, 0.02, -10)};
            myModel3DGroup.Children.Add(getAsix(points, Color.FromRgb(0, 0, 255)));

            points = new Point3D[] {new Point3D(10,-0.02, -0.02), new Point3D(10, -0.02, 0.02),
            new Point3D(10, 0.02, -0.02), new Point3D(10, 0.02, 0.02), new Point3D(-10,-0.02, -0.02),
            new Point3D(-10, -0.02, 0.02), new Point3D(-10, 0.02, -0.02), new Point3D(-10, 0.02, 0.02)};
            myModel3DGroup.Children.Add(getAsix(points, Color.FromRgb(0, 255, 0)));

            points = new Point3D[] {new Point3D(-0.02, 10, -0.02), new Point3D(0.02, 10, -0.02),
            new Point3D(-0.02, 10, 0.02), new Point3D(0.02, 10, 0.02), new Point3D(-0.02, -10, -0.02),
            new Point3D(0.02, -10, -0.02), new Point3D(-0.02, -10, 0.02), new Point3D(0.02, -10, 0.02)};
            myModel3DGroup.Children.Add(getAsix(points, Color.FromRgb(255, 0, 0)));

            myModel3DGroup.Children.Add(getBox());

            myModelVisual3D.Content = myModel3DGroup;

            myViewport3D.Children.Add(myModelVisual3D);
            cube = getCube();
        }

        private PerspectiveCamera getPerspectiveCamera()
        {
            PerspectiveCamera myPCamera = new PerspectiveCamera();
            double q = 45, f = 45;
            myPCamera.Position = new Point3D(radius * Math.Sin(q) * Math.Cos(f), radius * Math.Sin(q) * Math.Sin(f), radius * Math.Cos(q));
            myPCamera.LookDirection = new Vector3D(-myPCamera.Position.X, -myPCamera.Position.Y, -myPCamera.Position.Z);
            myPCamera.UpDirection = new Vector3D(0, 0, 1);
            myPCamera.FieldOfView = 60;
            return myPCamera;
        }

        private AmbientLight getDirectionalLight()
        {
            AmbientLight myDirectionalLight = new AmbientLight();
            myDirectionalLight.Color = Colors.White;
            return myDirectionalLight;
        }

        private Point3DCollection createVertexPositions()
        {
            Point3DCollection myPositionCollection = new Point3DCollection();
            for (float y = -3; y <= 3; y += 0.15f)
            {
                for (float x = -3; x <= 3; x += 0.15f)
                {
                    myPositionCollection.Add(new Point3D(x, y, function.calc(x, y)));
                }
            }
            return myPositionCollection;
        }

        private Point3D[,] createParaboloid()
        {
            Point3D[,] myPositionCollection = new Point3D[len,len];
            for (int y = -20; y <= 20; y++)
            {
                for (int x = -20; x <= 20; x++)
                {
                    myPositionCollection[x+20, y+20] = new Point3D(x*0.15, y * 0.15, (x * 0.15 - point.X)* (x * 0.15 - point.X) + (y * 0.15 - point.Y) * (y * 0.15 - point.Y));
                }
            }
            return myPositionCollection;
        }

        private GeometryModel3D getTriangle(Point3D[] points, int number)
        {
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(points[0]);
            myPositionCollection.Add(points[1]);
            myPositionCollection.Add(points[2]);
            myMeshGeometry3D.Positions = myPositionCollection;

            PointCollection myTextureCoordinatesCollection = new PointCollection();
            myTextureCoordinatesCollection.Add(new Point(0, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 0));
            myTextureCoordinatesCollection.Add(new Point(1, 1));
            myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(0);
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            myGeometryModel.Geometry = myMeshGeometry3D;

            double height = (Math.Min(myPositionCollection[0].Z, Math.Min(myPositionCollection[1].Z, myPositionCollection[2].Z)) +
                Math.Max(myPositionCollection[0].Z, Math.Max(myPositionCollection[1].Z, myPositionCollection[2].Z))) / 2;
            byte r = (byte)Math.Max(Math.Min((int)((height) / 4 * 255), 255), 0);
            byte g = number == 1 ?
                (byte)Math.Max(Math.Min((int)(-(Math.Abs(height) / 4 * 255 / 1.25) + 255 / 1.25), 255 / 1.25), 0) :
                (byte)Math.Max(Math.Min((int)(-(Math.Abs(height) / 4 * 255) + 255), 255), 0);
            byte b = (byte)Math.Max(Math.Min((int)((-height) / 4 * 255), 255), 0);
            Color color = Color.FromRgb(r, g, b);
            SolidColorBrush myHorizontalGradient = new SolidColorBrush(color);
            myHorizontalGradient.Opacity = 0.8;

            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            myGeometryModel.Material = myMaterial;

            return myGeometryModel;
        }

        private GeometryModel3D getAsix(Point3D[] points, Color color)
        {
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            Point3DCollection myPositionCollection = new Point3DCollection();
            for (int i = 0; i < points.Length; i++)
            {
                myPositionCollection.Add(points[i]);
            }
            myMeshGeometry3D.Positions = myPositionCollection;

            PointCollection myTextureCoordinatesCollection = new PointCollection();
            for (int i = 0; i < 4; i++)
            {
                myTextureCoordinatesCollection.Add(new Point(0, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 0));
            }
            myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(0);

            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(1);

            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);

            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(2);
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            myGeometryModel.Geometry = myMeshGeometry3D;

            SolidColorBrush myHorizontalGradient = new SolidColorBrush(color);
            myHorizontalGradient.Opacity = 0.9;

            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            myGeometryModel.Material = myMaterial;

            return myGeometryModel;
        }

        private GeometryModel3D getBox()
        {
            GeometryModel3D myGeometryModel = new GeometryModel3D();
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(-50, -50, -50));
            myPositionCollection.Add(new Point3D(50, -50, -50));
            myPositionCollection.Add(new Point3D(50, 50, -50));
            myPositionCollection.Add(new Point3D(-50, 50, -50));
            myPositionCollection.Add(new Point3D(-50, -50, 50));
            myPositionCollection.Add(new Point3D(50, -50, 50));
            myPositionCollection.Add(new Point3D(50, 50, 50));
            myPositionCollection.Add(new Point3D(-50, 50, 50));
            myMeshGeometry3D.Positions = myPositionCollection;

            PointCollection myTextureCoordinatesCollection = new PointCollection();
            for (int i = 0; i < 6; i++)
            {
                myTextureCoordinatesCollection.Add(new Point(0, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 0));
            }
            myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);

            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(6);

            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(7);

            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(4);

            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);

            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(5);
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            myGeometryModel.Geometry = myMeshGeometry3D;

            SolidColorBrush myHorizontalGradient = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            myGeometryModel.Material = myMaterial;

            return myGeometryModel;
        }

        private ModelVisual3D getCube()
        {
            Model3DGroup myModel3DGroup = new Model3DGroup();
            ModelVisual3D myModelVisual3D = new ModelVisual3D();

            myModel3DGroup.Children.Add(getDirectionalLight());

            GeometryModel3D myGeometryModel = new GeometryModel3D();
            MeshGeometry3D myMeshGeometry3D = new MeshGeometry3D();

            Point3DCollection myPositionCollection = new Point3DCollection();
            myPositionCollection.Add(new Point3D(-0.5, -0.5, -0.5));
            myPositionCollection.Add(new Point3D(0.5, -0.5, -0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, -0.5));
            myPositionCollection.Add(new Point3D(-0.5, 0.5, -0.5));
            myPositionCollection.Add(new Point3D(-0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, -0.5, 0.5));
            myPositionCollection.Add(new Point3D(0.5, 0.5, 0.5));
            myPositionCollection.Add(new Point3D(-0.5, 0.5, 0.5));
            myMeshGeometry3D.Positions = myPositionCollection;

            PointCollection myTextureCoordinatesCollection = new PointCollection();
            for (int i = 0; i < 6; i++)
            {
                myTextureCoordinatesCollection.Add(new Point(0, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 0));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(1, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 1));
                myTextureCoordinatesCollection.Add(new Point(0, 0));
            }
            myMeshGeometry3D.TextureCoordinates = myTextureCoordinatesCollection;

            Int32Collection myTriangleIndicesCollection = new Int32Collection();
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(4);

            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(5);

            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(6);

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(7);

            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(7);
            myTriangleIndicesCollection.Add(4);
            myTriangleIndicesCollection.Add(5);
            myTriangleIndicesCollection.Add(6);
            myTriangleIndicesCollection.Add(7);

            myTriangleIndicesCollection.Add(0);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(1);
            myTriangleIndicesCollection.Add(3);
            myTriangleIndicesCollection.Add(2);
            myTriangleIndicesCollection.Add(1);
            myMeshGeometry3D.TriangleIndices = myTriangleIndicesCollection;

            myGeometryModel.Geometry = myMeshGeometry3D;

            SolidColorBrush myHorizontalGradient = new SolidColorBrush(Color.FromRgb(200, 0, 255));
            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            myGeometryModel.Material = myMaterial;

            myModel3DGroup.Children.Add(myGeometryModel);

            myModelVisual3D.Content = myModel3DGroup;

            return myModelVisual3D;
        }
    }
}
