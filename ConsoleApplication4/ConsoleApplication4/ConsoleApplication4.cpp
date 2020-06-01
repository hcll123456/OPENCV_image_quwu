// ConsoleApplication4.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include<Windows.h>
#include <opencv2\opencv.hpp>
#include <opencv2\core\core.hpp>
#include <opencv2\highgui\highgui.hpp>
#include <opencv2\imgproc\imgproc.hpp>
#include <opencv2\objdetect\objdetect.hpp>
#include <opencv2\imgproc\types_c.h>
#include <iostream>
#include <string>
#include <cstdlib>

using namespace cv;
using namespace std;

Mat grayStretch(cv::Mat src, double lowcut, double highcut);

int main(int argc, char* argv[])
{
    VideoCapture capture;
    Mat frame, dst;



    frame = capture.open(argv[1]);
    if (!capture.isOpened())
    {
        printf("can not open ...\n");
        return -1;
    }
    Size size = Size(capture.get(CAP_PROP_FRAME_WIDTH), capture.get(CAP_PROP_FRAME_HEIGHT));

    Rect rect(0.4* capture.get(CAP_PROP_FRAME_WIDTH), 0.33* capture.get(CAP_PROP_FRAME_HEIGHT), 0.2* capture.get(CAP_PROP_FRAME_WIDTH), 0.33* capture.get(CAP_PROP_FRAME_HEIGHT));

    VideoWriter writer;
    writer.open("D:\\tmp\\tmp.mp4", CAP_OPENCV_MJPEG, 24, size, true);
    
    Mat channels[3];

    while (capture.read(frame))
    {

        split(frame, channels);
        for (int c = 0; c < 3; c++)
            channels[c] = grayStretch(channels[c], 0.001, 0.5);
        merge(channels, 3, dst);
        Mat result = frame.clone();
        Mat tmp = result(rect);
        dst(rect).copyTo(tmp);

        writer.write(result);
    }
    writer.release();
    capture.release();
    return 0;
}


cv::Mat grayStretch(cv::Mat src, double lowcut, double highcut)
{
    //[1]--统计各通道的直方图
    //参数
    const int bins = 256;
    int hist_size = bins;
    float range[] = { 0,255 };
    const float* ranges[] = { range };
    MatND desHist;
    int channels = 0;
    //计算直方图
    calcHist(&src, 1, &channels, Mat(), desHist, 1, &hist_size, ranges, true, false);
    //[1]

    //[2] --计算上下阈值
    int pixelAmount = src.rows * src.cols; //像素总数
    float Sum = 0;
    long long int minValue, maxValue;
    //求最小值
    for (int i = 0; i < bins; i++)
    {
        Sum = Sum + desHist.at<float>(i);
        if (Sum >= pixelAmount * lowcut * 0.01)
        {
            minValue = i;
            //qDebug() << "minValue" << minValue;
            break;
        }
    }

    //求最大值
    Sum = 0;
    for (int i = bins - 1; i >= 0; i--)
    {
        Sum = Sum + desHist.at<float>(i);
        if (Sum >= pixelAmount * highcut * 0.01)
        {
            maxValue = i;
            //qDebug() << "maxValue" << maxValue;
            break;
        }
    }
    //[2]

    //[3] --对各个通道进行线性拉伸
    Mat dst = src;
    //判定是否需要拉伸
    if (minValue > maxValue)
        return src;

    for (int i = 0; i < src.rows; i++)
        for (int j = 0; j < src.cols; j++)
        {
            if (src.at<uchar>(i, j) < minValue)
                dst.at<uchar>(i, j) = 0;
            if (src.at<uchar>(i, j) > maxValue)
                dst.at<uchar>(i, j) = 255;
            else
            {
                //注意这里做除法要使用double类型
                double pixelValue = ((src.at<uchar>(i, j) - minValue) /
                    (double)(maxValue - minValue)) * 255;
                dst.at<uchar>(i, j) = (int)pixelValue;
            }
        }
    //[3]

    return dst;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门使用技巧: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
