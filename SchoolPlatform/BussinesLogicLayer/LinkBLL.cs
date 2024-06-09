using SchoolPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolPlatform.BussinesLogicLayer
{
    class LinkBLL
    {
        object? selectedObject;
        private MyContext context = new MyContext();

        public void Linking(object obj)
        {
            if(selectedObject==null)
            {
                selectedObject = obj;
            }
            else 
            {
                if (obj is Subject && selectedObject is Class)
                {
                    Subject sub = obj as Subject;
                    Class cl = selectedObject as Class;
                    int id1 = cl.ClassId;
                    int id2 = sub.SubjectId;
                    var cs = context.ClassSubjects.FirstOrDefault(c => c.SubjectId == id2 && c.ClassId == id1);
                    if(cs==null)
                    {
                        context.ClassSubjects.Add(new() { ClassId = id1, SubjectId = id2 });
                        context.SaveChanges();
                        
                    }
                    else
                    {
                        MessageBox.Show("The class already has this subject");
                    }
                    selectedObject = null;
                }
                else if (obj is Class && selectedObject is Subject) 
                {
                    Subject sub = selectedObject as Subject;
                    Class cl = obj as Class;
                    int id1 = cl.ClassId;
                    int id2 = sub.SubjectId;
                    var cs = context.ClassSubjects.FirstOrDefault(c => c.SubjectId == id2 && c.ClassId == id1);
                    if (cs == null)
                    {
                        context.ClassSubjects.Add(new() { ClassId = id1, SubjectId = id2 });
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The class already has this subject");
                    }
                    selectedObject = null;
                }
                else if(obj is Teacher && selectedObject is Subject)
                {
                    Teacher teach=obj as Teacher;
                    Subject sub=selectedObject as Subject;
                    int id1 = teach.TeacherId;
                    int id2 = sub.SubjectId;
                    var ts=context.TeacherSubjects.FirstOrDefault(t=>t.TeacherId == id1 && t.SubjectId==id2);
                    if(ts== null)
                    {
                        context.TeacherSubjects.Add(new() { SubjectId = id2, TeacherId = id1 });
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The teacher is already associated with this subject");
                    }
                    selectedObject = null;
                }
                else if(obj is Subject && selectedObject is Teacher)
                {
                    Teacher teach = selectedObject as Teacher;
                    Subject sub = obj as Subject;
                    int id1 = teach.TeacherId;
                    int id2 = sub.SubjectId;
                    var ts = context.TeacherSubjects.FirstOrDefault(t => t.TeacherId == id1 && t.SubjectId == id2);
                    if (ts == null)
                    {
                        context.TeacherSubjects.Add(new() { SubjectId = id2, TeacherId = id1 });
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("The teacher is already associated with this subject");
                    }
                    selectedObject = null;
                }
                else if(obj is Student && selectedObject is Class)
                {
                    Student stud = obj as Student;
                    Class class1=selectedObject as Class;
                    stud.ClassId = class1.ClassId;
                    context.Update(stud);
                    context.SaveChanges();
                    selectedObject= null;
                }
                else if(obj is Class && selectedObject is Student) 
                {
                    Student stud = selectedObject as Student;
                    Class class1 = obj as Class;
                    stud.ClassId = class1.ClassId;
                    context.Update(stud);
                    context.SaveChanges();
                    selectedObject = null;
                }
                else if(obj is HomeroomTeacher && selectedObject is Class)
                {
                    HomeroomTeacher hmt=obj as HomeroomTeacher;
                    Class class1=selectedObject as Class;
                    class1.HomeroomTeacherId = hmt.HomeroomTeacherId;
                    context.Update(class1);
                    context.SaveChanges();
                    selectedObject = null;
                }
                else if(obj is Class && selectedObject is HomeroomTeacher)
                {
                    HomeroomTeacher hmt = selectedObject as HomeroomTeacher;
                    Class class1 = obj as Class;
                    class1.HomeroomTeacherId = hmt.HomeroomTeacherId;
                    context.Update(class1);
                    context.SaveChanges();
                    selectedObject = null;
                }
                selectedObject=null;
            }
        }
    }
}
