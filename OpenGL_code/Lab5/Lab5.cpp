#include <GL/glut.h>
//#include <cmath>
#include <FreeImage.h> 
#define _USE_MATH_DEFINES
#define _SPEED_K 15
#include <math.h>

#define ITERCOUNTSPHERE 5

int x_o, y_o = 0;
float scale = 0.01f;
float a,b = 0.0f;
float alpha,beta = 0.0f;
float del_alpha,del_beta = 0.0f;
float x_n, y_n, z_n; 
float x[210] = {0};
float y[210] = {0};
float z[210] = {0};
float rad = 5;
float angle1 = 0.0f;
float angle2 = 0.0f;
float angle3 = 0.0f;
float angle4 = 0.0f;
float angle5 = 0.0f;
float angle6 = 0.0f;
float angle7 = 0.0f;
float angle8 = 0.0f;
float angle9 = 0.0f;

GLuint sphere_texture;


void RenderSphere(float radius, GLuint texture)
{
	glPushMatrix();
	glScalef(radius,radius,radius);
	glColor3f(1.0f, 1.0f, 1.0f);
	float k = 0.0f;
	float s = 0.0f;
	float k_d = 1.0f / (ITERCOUNTSPHERE * 2);
	float s_d = 1.0f / ITERCOUNTSPHERE;
	glBindTexture (GL_TEXTURE_2D, texture);
	for (float i = 0.0f; i < M_PI; i += M_PI / ITERCOUNTSPHERE ) {
			for (float j = 0.0f; j < 2* M_PI; j += M_PI / ITERCOUNTSPHERE ) {
				glBegin(GL_QUADS);
				glTexCoord2f(k,s);
				glNormal3f(sin(i) * cos(j), sin(i) * sin(j), cos(i));
				glVertex3d(sin(i) * cos(j), sin(i) * sin(j), cos(i));

				glTexCoord2f(k,s+s_d);
				glNormal3f(sin(i + M_PI / ITERCOUNTSPHERE ) * cos(j ), sin(i + M_PI / ITERCOUNTSPHERE ) * sin(j), cos(i + M_PI / ITERCOUNTSPHERE ));
				glVertex3d(sin(i + M_PI / ITERCOUNTSPHERE ) * cos(j ), sin(i + M_PI / ITERCOUNTSPHERE ) * sin(j), cos(i + M_PI / ITERCOUNTSPHERE ));

				glTexCoord2f(k+k_d,s+s_d);
				glNormal3f(sin(i + M_PI / ITERCOUNTSPHERE ) * cos(j + M_PI / ITERCOUNTSPHERE ), sin(i + M_PI / ITERCOUNTSPHERE ) * sin(j + M_PI / ITERCOUNTSPHERE ), cos(i + M_PI / ITERCOUNTSPHERE ));
				glVertex3d(sin(i + M_PI / ITERCOUNTSPHERE ) * cos(j + M_PI / ITERCOUNTSPHERE ), sin(i + M_PI / ITERCOUNTSPHERE ) * sin(j + M_PI / ITERCOUNTSPHERE ), cos(i + M_PI / ITERCOUNTSPHERE ));

				glTexCoord2f(k+k_d,s);
				glNormal3f(sin(i) * cos(j + M_PI / ITERCOUNTSPHERE ), sin(i) * sin(j + M_PI / ITERCOUNTSPHERE ), cos(i));
				glVertex3d(sin(i) * cos(j + M_PI / ITERCOUNTSPHERE ), sin(i) * sin(j + M_PI / ITERCOUNTSPHERE ), cos(i));

				glEnd();
				k += k_d;
 			}
			k = 0.0;
			s += s_d;
	}
	glBindTexture (GL_TEXTURE_2D, 0);
	glPopMatrix();
}


void ChangeSize(int w, int h)
{
	if (h == 0) { h = 1; }
	float ratio = w * 1.0 / h;
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glViewport(0,0,w,h);
	gluPerspective(75.0f,ratio,0.1f,1000.0f);
	glMatrixMode(GL_MODELVIEW);
}

void RenderSceneTriangle(void)
{
	glEnable(GL_COLOR_MATERIAL); 
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glLoadIdentity();
	gluLookAt(x_n,y_n,z_n,0,0,0,0,1,0);

	//������������ ������������
	glDisable(GL_LIGHTING);
	glBegin(GL_LINES);
	glColor4f(1,0,0,1);
	glVertex3f(0.0f,0.0f,0.0f);
	glVertex3f(50.0f,0.0f,0.0f);
	glEnd();
	glBegin(GL_LINES);
	glColor4f(0,1,0,1);
	glVertex3f(0.0f,0.0f,0.0f);
	glVertex3f(0.0f,50.0f,0.0f);
	glEnd();
	glBegin(GL_LINES);
	glColor4f(0,0,1,1);
	glVertex3f(0.0f,0.0f,0.0f);
	glVertex3f(0.0f,0.0f,50.0f);
	glEnd();
	
	//����
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_LIGHT0);
	glEnable(GL_LIGHTING);
	GLfloat light0_position[] = {0.0, 0.0, 0.0, 1.0};
	GLfloat light0_diffuze[] = {1, 1, 1};
	glLightfv(GL_LIGHT0,GL_POSITION,light0_position);
	glLightfv(GL_LIGHT0,GL_DIFFUSE,light0_diffuze);
	glDisable(GL_LIGHTING);

	glColor3f(1.0, 1.0, 0.0);
	glutSolidSphere(5.0, 50.0, 50.0);

	glEnable(GL_LIGHTING);

	//1
	glRotatef(angle1,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(10.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//2
	glRotatef(angle2,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(20.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//3
	glRotatef(angle3,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(30.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//4
	glRotatef(angle4,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(40.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//5
	glRotatef(angle5,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(80.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//6
	glRotatef(angle6,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(110.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//7
	glRotatef(angle7,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(150.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//8
	glRotatef(angle8,0.0f,1.0f,0.0f);
	glPushMatrix();
	glTranslatef(180.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//9
	glRotatef(angle9,0.0f,1.0f,0.0f);
	glRotatef(30.0,1.0f,0.0f,0.0f);
	glPushMatrix();
	glTranslatef(200.0f,0.0f,0.0f);

	RenderSphere(1.0f,sphere_texture);
	glPopMatrix();

	//�����
	glDisable(GL_LIGHTING);
	glutSwapBuffers();
}

void func(int x, int y)
{
	int dx, dy = 0;
	dx = x_o - x;
	dy = y_o - y;
	a = a + dy*scale;
	b = b + dx*scale;
	x_n = cos(b)*sin(a)*50;
	y_n = cos(a)*50;
	z_n = sin(b)*sin(a)*50;
	x_o = x;
	y_o = y;
}


GLuint Tex(char *file)
{
	GLuint texture;
	FREE_IMAGE_FORMAT fif = FIF_UNKNOWN;
	FIBITMAP * dib(0);
	BYTE* bits(0);
	unsigned int width(0), height(0);
	fif = FreeImage_GetFileType(file, 0);

	if (fif == FIF_UNKNOWN)
	return 0;

	if (FreeImage_FIFSupportsReading(fif))
	dib = FreeImage_Load(fif, file);

	if(!dib)
	return 0;

	bits = FreeImage_GetBits(dib);
	width = FreeImage_GetWidth(dib);
	height = FreeImage_GetHeight(dib);

	if (bits == 0 || width == 0 || height == 0)
	return 0;

	glGenTextures (1, &texture);
	glBindTexture (GL_TEXTURE_2D, texture);

	glTexParameteri (GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);
	glTexParameteri (GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);

	glTexParameteri (GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
	glTexParameteri (GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);

	glTexImage2D (GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_BGR_EXT, GL_UNSIGNED_BYTE, bits);

	glBindTexture (GL_TEXTURE_2D, 0);

	FreeImage_Unload (dib);

	return texture;
}


void update()
{
	angle1 += 0.47f/_SPEED_K;
	angle2 += 0.35f/_SPEED_K;
	angle3 += 0.29f/_SPEED_K;
	angle4 += 0.24f/_SPEED_K;
	angle5 += 0.13f/_SPEED_K;
	angle6 += 0.09f/_SPEED_K;
	angle7 += 0.06f/_SPEED_K;
	angle8 += 0.05f/_SPEED_K;
	angle9 += 0.04f/_SPEED_K;
	glutPostRedisplay();
}




	int main(int argc, char** argv)
{
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH);
	glutInitWindowPosition(100,100);
	glutInitWindowSize(1000,1000);
	glutCreateWindow("OpenGL");

	sphere_texture = Tex("Earth_hr_clouds.jpg");

	glClearColor(0.0, 0.0, 0.0, 0.0); 
	glEnable(GL_TEXTURE_2D);
	glutDisplayFunc(RenderSceneTriangle);
	glutReshapeFunc(ChangeSize);
	glutIdleFunc(update);
	glutPassiveMotionFunc(func);
	glEnable(GL_DEPTH_TEST);
	glutMainLoop();

	return 0;
}

