using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutolocatorWPF.Models
{
        class AllModels
        {
                public static Dictionary<int, QuestionParameter> questions = new Dictionary<int, QuestionParameter>();
                public AllModels()
                {

                        //Intrebari usoare
                        questions.Add(1, new QuestionParameter() { Question = "Care este capitala Romaniei?", Answers = "Iasi,Timisoara,Bucuresti,Arad", RightAnswersIndex = "3", TypeAnswers = "Hidden" });//Visible/Hidden
                        questions.Add(2, new QuestionParameter() { Question = "Cine a fost presedinte pana acum?", Answers = "Traian Basescu,Iohannis,Ponta", RightAnswersIndex = "1,2", TypeAnswers = "Visible" });
                        questions.Add(3, new QuestionParameter() { Question = "Cul il cheama pe imparatul roman?", Answers = "Tiberius,Claudius,Cezar,Mitica", RightAnswersIndex = "1,2,3", TypeAnswers = "Visible" });
                        questions.Add(4, new QuestionParameter() { Question = "Cati ani are un deceniu?", Answers = "35 de ani,10 ani,100 de ani", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(5, new QuestionParameter() { Question = "Care este prima planeta de la soare?", Answers = "Mercur,Venus,Pamant,Pluto,Saturn,Uranus", RightAnswersIndex = "1", TypeAnswers = "Hidden" });
                        questions.Add(6, new QuestionParameter() { Question = "Care este moneda americana?", Answers = "Euro,Dolar,Lira", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(7, new QuestionParameter() { Question = "Care este cea mai populata tara?", Answers = "SUA,Republica Populara Chineza,Japonia,Tailanda,Nici una din cele de mai sus,Test", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(8, new QuestionParameter() { Question = "Cine este Mark Zuckerberg?", Answers = "Programator,Co-fondatorul si presedintele Facebook,Scriitor", RightAnswersIndex = "1,2", TypeAnswers = "Visible" });
                        questions.Add(9, new QuestionParameter() { Question = "Ce faci cand parasuta nu s-a depliat din sac in timpul saltului cu parasuta?", Answers = "Largare,Deschizi rezerva,Te panichezi", RightAnswersIndex = "1,2", TypeAnswers = "Visible" });
                        questions.Add(10, new QuestionParameter() { Question = "Ce PlayStation a aparut in 2020?", Answers = "PS3,PS4,PS5", RightAnswersIndex = "3", TypeAnswers = "Hidden" });

                        //Intrebari medii
                        questions.Add(11, new QuestionParameter() { Question = "Care este cel mai inalt varf din lume?", Answers = "Everest,Aconcagua,Elbrus", RightAnswersIndex = "1", TypeAnswers = "Hidden" });
                        questions.Add(12, new QuestionParameter() { Question = "Ce aripa e mai buna pentru zbor de distanta?", Answers = "Parasuta dreptunghiulara,Parasuta rotunda,Parapanta", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(13, new QuestionParameter() { Question = "Cine este cel mai inalt om din lume?", Answers = "Sultan Kosen,Chandra BahadurBruce Lee", RightAnswersIndex = "1", TypeAnswers = "Hidden" });
                        questions.Add(14, new QuestionParameter() { Question = "Cati copii a avut Stefan cel Mare?", Answers = "10 copii,9 copii,7 copii", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(15, new QuestionParameter() { Question = "Care este viteza luminii?", Answers = "299.729.458 metri pe secunda,302.106.919.7 metri pe secunda,299.792 kilometri pe secunda", RightAnswersIndex = "1,3", TypeAnswers = "Visible" });
                        questions.Add(16, new QuestionParameter() { Question = "In ce unitate se masoara unghiurile?", Answers = "milimetri patrati,Metri,Grade,minute,secunde", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(17, new QuestionParameter() { Question = "Cate grade are un triunghi dreptunghic?", Answers = "90,360,180", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(18, new QuestionParameter() { Question = "Care este numarul de evanghelisti ai bibliei?", Answers = "Doi evanghelisti,Trei evanghelisti,Patru evanghelisti", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(19, new QuestionParameter() { Question = "Complexitatea structurii de date HASHTABLE pentru a extrage elementul?", Answers = "O(1),O(n),O(logn),O(n*n)", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(20, new QuestionParameter() { Question = "De la ce intaltime sar studentii de la parasutism?", Answers = "1200 metri,3937 picioare,47244 inchi,15Newton", RightAnswersIndex = "1,2,3", TypeAnswers = "Visible" });

                        //Intrebari grele
                        questions.Add(21, new QuestionParameter() { Question = "Cate celule are parafoilul?", Answers = "5 celule,9 celule,7 celule,12 celule", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(22, new QuestionParameter() { Question = "Care este acceleratia gravitationala a lunei?", Answers = "9.8m/s,1.6m/s,2.9m/s,3.3m/s,4.6m/s", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(23, new QuestionParameter() { Question = "Cine a fondat Microsoft?", Answers = "Bill Gates,Paul Allen,Mark Zuckerberg,Victor Cerbescu", RightAnswersIndex = "1,2", TypeAnswers = "Visible" });
                        questions.Add(24, new QuestionParameter() { Question = "Ce este un infrasunet?", Answers = "Un sunet ce nu poate fi auzit de urechea umana,Sunete ce pot fi auzite de urechea umana,Vibratii cu frecventa cuprinsa intre 0,001 Hz si 20 Hz,Nici una din cele de mai sus", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(25, new QuestionParameter() { Question = "Care este greutatea maxima ce poate fi transportata de un elefant?", Answers = "3000 kg,9000 kg,1000 kg", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(26, new QuestionParameter() { Question = "Care este cel mai comun element din scoarta Pamantului?", Answers = "Oxigen,Aluminiu,Fier,Aur,Argint,Cupru", RightAnswersIndex = "1", TypeAnswers = "Hidden" });
                        questions.Add(27, new QuestionParameter() { Question = "La ce varsta a murit Adolf Hitler?", Answers = "27 de ani,49 de ani,56 de ani,2 ani", RightAnswersIndex = "3", TypeAnswers = "Hidden" });
                        questions.Add(28, new QuestionParameter() { Question = "Cat traieste in medie o antilopa?", Answers = "10 ani,15 ani", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                        questions.Add(29, new QuestionParameter() { Question = "ate fire de par are un om in cap?", Answers = "100.000 de fire,150.000 de fire", RightAnswersIndex = "1", TypeAnswers = "Hidden" });
                        questions.Add(30, new QuestionParameter() { Question = "Care este cel mai adanc lac din lume?", Answers = "Lacul Matano,Lacul Baikal,Crater Lake,Altul", RightAnswersIndex = "2", TypeAnswers = "Hidden" });
                }

                public static List<QuestionParameter> Data = new List<QuestionParameter>();
        }
        public class QuestionParameter
        {
                public string Question;
                public string Answers;
                public string RightAnswersIndex;
                public string TypeAnswers;
        }


}
