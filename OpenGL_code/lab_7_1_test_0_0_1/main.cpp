#include <GL/glut.h> 
#include <FreeImage.h> 
#define _USE_MATH_DEFINES 
#include <math.h> 
#define ITERCOUNT 8
#define ITERCOUNTSPHERE 5

int x_o, y_o = 0; 
float scale = 0.01f; 
float a, b = 10.0f; 
float x_n, y_n, z_n; 
double x = 0; 
const double amp = 0.5; 
float globus_rotate = 0.0f;

GLuint top, bottom, can, background, sphere_texture, niz;

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

void renderScene() 
{ 
	glEnable(GL_COLOR_MATERIAL); 
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT); 
	glLoadIdentity(); 
	gluLookAt(x_n, y_n, z_n, 0, 0, 0, 0, 1, 0); 
	glEnable(GL_LIGHT0); 
	glEnable(GL_LIGHTING); 
	GLfloat light0_position[] = { 10.0,10.0,-2.0,1.0 }; 
	GLfloat light0_diffusion[] = {1,1,1,1}; 
	glLightfv(GL_LIGHT0, GL_POSITION, light0_position); 
	glLightfv(GL_LIGHT0, GL_DIFFUSE, light0_diffusion); 
	
	
	glDisable(GL_LIGHTING); 
	glBegin(GL_LINES); 
	glColor4f(1, 0, 0, 1); 
	glVertex3f(0.0f, 0.0f, 0.0f); 
	glVertex3f(100.0f, 0.0f, 0.0f); 
	glEnd(); 
	glBegin(GL_LINES); 
	glColor4f(0, 1, 0, 1); 
	glVertex3f(0.0f, 0.0f, 0.0f); 
	glVertex3f(0.0f, 100.0f, 0.0f); 
	glEnd(); 
	glBegin(GL_LINES); 
	glColor4f(0, 0, 1, 1); 
	glVertex3f(0.0f, 0.0f, 0.0f); 
	glVertex3f(0.0f, 0.0f, 100.0f); 
	glEnd();
	
	//цилиндр
	glPushMatrix();
	glTranslatef(0.0f,-1.0f,-2.0f);
	glEnable(GL_LIGHTING);
	glColor4f(1, 1, 1, 1); 
	glPushMatrix();
	glScalef(0.5f, 0.5f, 0.5f); 
	float j = 0;
	glBindTexture (GL_TEXTURE_2D, bottom);
	for (int i = 1; i <= ITERCOUNT; i++) 
	{ 
		glBegin(GL_TRIANGLES); 
		//glColor4f(1, 0, 0, 1);
		glTexCoord2f(0.5, 0.5);
		glNormal3f(0.0f,-1.0f,0.0f);
		glVertex3f(0.0f, 0.0f, 0.0f); 
		//glColor4f(0, 0, 1, 1);
		glTexCoord2f(0.5 + 0.4123*cos(j), 0.5 + 0.4123*sin(j));
		glNormal3f(0.0f,-1.0f,0.0f);
		glVertex3f(2.0f, 0.0f, 0.0f); 
		//glColor4f(0, 0, 1, 1); 
		//j += 2*M_PI / ITERCOUNT;
		glTexCoord2f(0.5 + 0.4123*cos(j),  0.5 + 0.4123*sin(j));
		//glTexCoord2f(2.0f * cos(60.0f * M_PI / 180), 2.0f * sin(60.0f * M_PI / 180));
		glNormal3f(0.0f,-1.0f,0.0f);
		glVertex3f(2.0f * cos(360.0f / ITERCOUNT * M_PI / 180), 0.0f, 2.0f * sin(360.0f / ITERCOUNT * M_PI / 180)); 
		glEnd(); 

		glRotatef(-1 * 360.0f / ITERCOUNT, 0.0f, 1.0f, 0.0f); 
	}
	glBindTexture (GL_TEXTURE_2D, can);
	float b = 0;
	for (int i = 1; i <= ITERCOUNT; i++) 
	{ 
		
		glBegin(GL_QUADS); 
		//glColor4f(0, 0, 1, 1); 
		glTexCoord2f(b, 0);
		glNormal3f(2.0f,0.0f,0.0f);
		glVertex3f(2.0f, 0.0f, 0.0f); 
		//glColor4f(0, 0, 1, 1); 
		glTexCoord2f(b, 1);
		glNormal3f(2.0f,0.0f,0.0f);
		glVertex3f(2.0f, 7.0f, 0.0f); 
		//glColor4f(0, 1, 0, 1); 
		glTexCoord2f(b += 1.0f / ITERCOUNT, 1);
		glNormal3f(2.0f * cos(-1 * 360.0f / ITERCOUNT * M_PI / 180),0.0f,2.0f * sin(-1 * 360.0f / ITERCOUNT * M_PI / 180));
		glVertex3f(2.0f * cos(-1 * 360.0f / ITERCOUNT * M_PI / 180), 7.0f, 2.0f * sin(-1 * 360.0f / ITERCOUNT * M_PI / 180)); 
		//glColor4f(0, 1, 0, 1); 
		glTexCoord2f(b, 0);
		glNormal3f(2.0f * cos(-1 * 360.0f / ITERCOUNT * M_PI / 180),0.0f,2.0f * sin(-1 * 360.0f / ITERCOUNT * M_PI / 180));
		glVertex3f(2.0f * cos(-1 * 360.0f / ITERCOUNT * M_PI / 180), 0.0f, 2.0f * sin(-1 * 360.0f / ITERCOUNT * M_PI / 180));

		glEnd(); 
		glRotatef(360.0f / ITERCOUNT, 0.0f, 1.0f, 0.0f); 
	}
	glBindTexture (GL_TEXTURE_2D, top);
	for (int i = 1; i <= ITERCOUNT; i++) 
	{ 
		
		glBegin(GL_TRIANGLES); 
		//glColor4f(1, 0, 0, 1); 
		glTexCoord2f(0.5, 0.5);
		glNormal3f(0.0f,1.0f,0.0f);
		glVertex3f(0.0f, 7.0f, 0.0f); 
		//glColor4f(0, 1, 0, 1); 
		glTexCoord2f(0.5 + 0.4123*cos(j), 0.5 + 0.4123*sin(j));
		glNormal3f(0.0f,1.0f,0.0f);
		glVertex3f(2.0f, 7.0f, 0.0f); 
		//glColor4f(0, 1, 0, 1); 
		j += 2*M_PI / ITERCOUNT;
		glTexCoord2f(0.5 + 0.4123*cos(j),  0.5 + 0.4123*sin(j));
		glNormal3f(0.0f,1.0f,0.0f);
		glVertex3f(2.0f * cos(360.0f / ITERCOUNT * M_PI / 180), 7.0f, 2.0f * sin(360.0f / ITERCOUNT * M_PI / 180)); 
		glEnd(); 

		glRotatef(-1 * 360.0f / ITERCOUNT, 0.0f, 1.0f, 0.0f); 
	} 

	//glColor4f(1, 1, 1, 1); 
	glBindTexture (GL_TEXTURE_2D, 0);
	//сфера
	
	glPopMatrix();
	glPopMatrix();
	glPushMatrix();
	glTranslatef(1.0f,1.0f,2.0f);

	glPushMatrix();
	glRotatef(90.0f,1.0f,0.0f,0.0f);

	glPushMatrix();
	glRotatef(globus_rotate,0.0f,0.0f,1.0f);
	float k = 0.0f;
	float s = 0.0f;
	float k_d = 1.0f / (ITERCOUNTSPHERE * 2);
	float s_d = 1.0f / ITERCOUNTSPHERE;
	glBindTexture (GL_TEXTURE_2D, sphere_texture);
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

	glPopMatrix();
	glPopMatrix();
	glPopMatrix();
	glBindTexture (GL_TEXTURE_2D, 0);
	//стенки
	glColor4f(1, 1, 1, 1); 
	glBindTexture (GL_TEXTURE_2D, background);
	//glPushMatrix();
	glScalef(3.0f,3.0f,3.0f);
	//задн€€
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);

		glTexCoord2f(0,0);
		glVertex3f(-2.0F, -1.0F, -2.0F); 

		glTexCoord2f(1,0);
		glVertex3f(-2.0F, -1.0F, 2.0F);

		glTexCoord2f(1,1);
		glVertex3f(-2.0F, 2.0F, 2.0F);

		glTexCoord2f(0,1);
		glVertex3f(-2.0F, 2.0F, -2.0F); 
	glEnd();

	//лева€
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);

		glTexCoord2f(0,0);
		glVertex3f(-2.0F, -1.0F, 2.0F); 

		glTexCoord2f(1,0);
		glVertex3f(3.0F, -1.0F, 2.0F); 

		glTexCoord2f(1,1);
		glVertex3f(3.0F, 2.0F, 2.0F);

		glTexCoord2f(0,1);
		glVertex3f(-2.0F, 2.0F, 2.0F);
	glEnd();

	//права€
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);
			
		glTexCoord2f(0,0);
		glVertex3f(-2.0F, -1.0F, -2.0F); 

		glTexCoord2f(1,0);
		glVertex3f(3.0F, -1.0F, -2.0F); 

		glTexCoord2f(1,1);
		glVertex3f(3.0F, 2.0F, -2.0F);

		glTexCoord2f(0,1);
		glVertex3f(-2.0F, 2.0F, -2.0F);
	glEnd();

	//нижний
	glBindTexture (GL_TEXTURE_2D, 0);
	glBindTexture (GL_TEXTURE_2D, niz);
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);

		glTexCoord2f(0,0);
		glVertex3f(-2.0F, -1.0F, -2.0F);

		glTexCoord2f(1,0);
		glVertex3f(-2.0F, -1.0F, 2.0F); 

		glTexCoord2f(1,1);
		glVertex3f(3.0F, -1.0F, 2.0F);
		 
		glTexCoord2f(0,1);
		glVertex3f(3.0F, -1.0F, -2.0F);
	glEnd();

	//верхн€€
	glBindTexture (GL_TEXTURE_2D, 0);
	glBindTexture (GL_TEXTURE_2D, background);
	glBegin(GL_QUADS);
	glNormal3f(1.0f, 0.0f, 0.0f);

		glTexCoord2f(0,0);
		glVertex3f(-2.0F, 2.0F, -2.0F);

		glTexCoord2f(1,0);
		glVertex3f(-2.0F, 2.0F, 2.0F); 

		glTexCoord2f(1,1);
		glVertex3f(3.0F, 2.0F, 2.0F);
		 
		glTexCoord2f(0,1);
		glVertex3f(3.0F, 2.0F, -2.0F);
	glEnd();
	glDisable(GL_LIGHTING);

	
	//glColor3f(1, 1, 0.3); 
	//glVertex3f(0.0F, 0.0F, 0.0F); 

	glEnd(); 



	glutSwapBuffers(); 


} 

void update() 
{ 
	x += 0.05; 
	globus_rotate += 0.05;
	glutPostRedisplay(); 
} 

void ChangeSize(int w, int h) 
{ 

	if (h == 0) 
	h = 1; 

	double ratio = (w * 1.0) / h; 
	glMatrixMode(GL_PROJECTION); 
	glLoadIdentity(); 
	glViewport(0, 0, w, h); 
	gluPerspective(45.0F, ratio, 0.1F, 500.0F); 
	glMatrixMode(GL_MODELVIEW); 

} 

void func(int x, int y) 
{ 
	int dx = 5, dy = 5; 
	dx = x_o - x; 
	dy = y_o - y; 
	a = a + dy * scale; 
	b = b + dx * scale; 
	x_n = cos(b) * sin(a) * 20; 
	y_n = cos(a) * 20; 
	z_n = sin(b) * sin(a) * 20; 
	x_o = x; 
	y_o = y; 
	glutPostRedisplay(); 
} 

int main(int argc, char** argv) 
{ 

	glutInit(&argc, argv); 
	glutInitDisplayMode(GLUT_RGBA | GLUT_DOUBLE | GLUT_DEPTH); 
	glutInitWindowPosition(100, 100); 
	glutInitWindowSize(1280, 720); 
	glutCreateWindow("Ѕаночка"); 

	top = Tex("Top.jpg");
	bottom = Tex("Bottom.jpg");
	can = Tex("Coka.jpg");
	background = Tex("Background.jpg");
	niz = Tex("grass.jpg");
	sphere_texture = Tex("Earth_hr_clouds.jpg");

	glClearColor(0.0, 0.0, 0.0, 0.0); 
	glEnable(GL_TEXTURE_2D);
	glEnable(GL_DEPTH_TEST); 
	glutIdleFunc(update); 
	glutDisplayFunc(renderScene); 
	glutReshapeFunc(ChangeSize); 
	glutPassiveMotionFunc(func); 
	glutMainLoop(); 

	return 0; 

}