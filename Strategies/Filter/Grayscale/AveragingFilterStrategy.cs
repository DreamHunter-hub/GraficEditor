using GraficEditor.imageSamples;
using GraficEditor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraficEditor.Strategies.Filter.Grayscale {
    public class AveragingFilterStrategy : IFilterStrategy {
        private FilterParameters _parameters;
        private Color[,] _colors;
        public ImageSample Filter(ImageSample image, FilterParameters parameters) {
            if (image is not GrayscaleImage grayscaleImage) {
                throw new ArgumentException("Image должен быть типа GrayscaleImage");
            }
            if (parameters.Radius == null) {
                throw new ArgumentException("Поле Radius в FilterParameters не должно быть null");
            }

            _parameters = parameters;
            _colors = grayscaleImage.Pixels;

            int width = image.Width;
            int height = image.Height;
            Color[,] colors = new Color[width, height];

            Parallel.For(0, width, x => {
                for(int y = 0; y < height; y++) {
                    double grayValueD = AverageNumber(x, y);
                    int grayValueI = Math.Min(Math.Abs((int)grayValueD), 255);
                    Color newColor = Color.FromArgb(grayValueI, grayValueI, grayValueI);
                    colors[x, y] = newColor;
                }
            });

            return new GrayscaleImage(colors);
        }
        private double AverageNumber(int centerX,int centerY) {
            double sum = 0;
            int countNumbers = 0;

            for(int x = centerX - (int)_parameters.Radius; x <= centerX + _parameters.Radius; x++) {
                for(int y = centerY - (int)_parameters.Radius; y <= centerY + _parameters.Radius; y++) {
                    if(x >= 0 && x < _colors.GetLength(0) && y >= 0 && y < _colors.GetLength(1)) {
                        sum += _colors[x, y].R;
                        countNumbers++;
                    }
                }
            }

            return sum / countNumbers;
        }
    }
}
