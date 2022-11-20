using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Logging;
using ProyectoIdentity.Models.ModelsJourney;

namespace ProyectoIdentity.Models.ModelTemplateJorney
{
    public class ModelSurvey
    {
        
        public  List<Category> Categorias { get; set; }

        private List<Opcion> OpcionesIniciales { get; set; }

        private List<Pregunta> preguntasIniciales { get; set; }


        private static List<Opcion> OpcionesLikkert1() {

            var OpcionesLik = new List<Opcion> {
                new Opcion { Id = 1, OpcionName = "No aplica" },
                new Opcion { Id = 2, OpcionName = "No cumple las expectativas" },
                new Opcion { Id = 3, OpcionName = "Necesita algunas mejoras" },
                new Opcion { Id = 4, OpcionName = "Cumple las expectativas" },
                new Opcion { Id = 5, OpcionName = "Supera las expectativas" },
            };

            return OpcionesLik;

        }


        private static List<Opcion> optionActividad2()
        {
            var OpcionesActividad = new List<Opcion> {

                new Opcion { Id = 6, OpcionName = "Actividades recreativas de tipo social con amigos o familiares" },
                new Opcion { Id = 7, OpcionName = "Actividades de asistencia a espectáculos como cine, teatro, música, etc." },
                new Opcion { Id = 8, OpcionName = "Actividades deportivas " },
                new Opcion { Id = 9, OpcionName = "Actividades para conocer y vivir la naturaleza" },
                new Opcion { Id = 10, OpcionName = "Actividades creativas como pintura, dibujo, fotografía, tocar música, artesanías o manualidades" },
                new Opcion { Id = 11, OpcionName = "Actividades lúdicas de juegos de mesa y salón como ajedrez, dominó, billar, ping-pong, etc." },
                new Opcion { Id = 12, OpcionName = "Videojuegos " },
                new Opcion { Id = 13, OpcionName = "Redes sociales e internet" },
                new Opcion { Id = 14, OpcionName = "Actividades de voluntariado" },
                new Opcion { Id = 15, OpcionName = "Lectura, poesía y literatura" },
                new Opcion { Id = 16, OpcionName = "Formación académica, entrenamientos y cursos" },
                new Opcion { Id = 17, OpcionName = "Otra ¿Cuál?" }
            };
            return OpcionesActividad;
        }

        private static List<Opcion> optionAcciones3()
        {
            var OpcionesAcciones = new List<Opcion>
            {
                new Opcion { Id = 18, OpcionName = "Ejercicio 2 o 3 veces a la semana"},
                new Opcion { Id = 19, OpcionName = "Actividades de ocio y tiempo libre (como las descritas en el numeral anterior)"},
                new Opcion { Id = 20, OpcionName = "Actividades para reducir el estrés (yoga, masajes, caminar, tiempo con los amigos, etc.)"},
                new Opcion { Id = 21, OpcionName = "Alimentación balanceada"},
                new Opcion { Id = 22, OpcionName = "Recibir chequeos de salud anuales"},
                new Opcion { Id = 23, OpcionName = "Asesoría sobre temas de salud y nutrición"},
                new Opcion { Id = 24, OpcionName = "Asesorías en temas tributarios y financieros"}
            };

            return OpcionesAcciones;
        }

        private static List<Opcion> OpcionTiempo4() {

            var OpcionesTiempo = new List<Opcion>
            {

                new Opcion { Id = 25, OpcionName = "No aplica" },
                new Opcion { Id = 26, OpcionName = "De 1 a 2 horas" },
                new Opcion { Id = 27, OpcionName = "De 2 a 4 horas" },
                new Opcion { Id = 28, OpcionName = "Más de 4 horas" }
            };

            return OpcionesTiempo;
        }

        private static List<Opcion> OpcionSintomas5()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 29, OpcionName = "Dolores de cuello, espalda o tensión muscular" },
                new Opcion { Id = 30, OpcionName = "Trastornos de sueño durante el día" },
                new Opcion { Id = 31, OpcionName = "Insomnio" },
                new Opcion { Id = 32, OpcionName = "Hipertensión" },
                new Opcion { Id = 33, OpcionName = "Cambios fuertes en el apetito" },
                new Opcion { Id = 34, OpcionName = "Falta de concentración" },
                new Opcion { Id = 35, OpcionName = "Desgano" },
                new Opcion { Id = 36, OpcionName = "Ninguno" }
            };
            return OpcionesTiempo;
        }


        private static List<Opcion> OpcionAnimo6()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 37, OpcionName = "Dificultad en las relaciones con otras personas" },
                new Opcion { Id = 38, OpcionName = "Sensación de aislamiento y desinterés" },
                new Opcion { Id = 39, OpcionName = "Sentimientos de frustración, de no haber hecho lo que quería en la vida" },
                new Opcion { Id = 40, OpcionName = "Disminución del rendimiento en el trabajo o poca creatividad" },
                new Opcion { Id = 41, OpcionName = "Deseo de cambiar de empleo" },
                new Opcion { Id = 42, OpcionName = "Sentimiento de soledad y miedo" },
                new Opcion { Id = 43, OpcionName = "Sentimiento de irritabilidad, mal humor, actitud o pensamiento negativo" },
                new Opcion { Id = 44, OpcionName = "Sentimiento de angustia, preocupación o tristeza" },
                new Opcion { Id = 45, OpcionName = "Sentimiento de \"no valer nada\" o \"no servir para nada\"" },
                new Opcion { Id = 46, OpcionName = "Ninguna" }
            };
            return OpcionesTiempo;
        }


        private static List<Opcion> OpcionMedicamento7()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 47, OpcionName = "Ninguna"},
                new Opcion { Id = 48, OpcionName = "Baja"},
                new Opcion { Id = 49, OpcionName = "Media"},
                new Opcion { Id = 50, OpcionName = "Alta"}

            };
            return OpcionesTiempo;
        }

        private static List<Opcion> OpcionMedicamento8()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 51, OpcionName = "Nunca"},
                new Opcion { Id = 52, OpcionName = "Entre 1 y 3 veces/mes " },
                new Opcion { Id = 53, OpcionName = "Entre 4 y 10 veces /mes"},
                new Opcion { Id = 54, OpcionName = "Más de 10 veces/mes"}

            };
            return OpcionesTiempo;
        }

        private static List<Opcion> OpcionesLista9() {
            var OpcionesTiempo = new List<Opcion>
            {
            new Opcion { Id = 55, OpcionName = "Salud" },
            new Opcion { Id = 56, OpcionName = "Ahorro" },
            new Opcion { Id = 57, OpcionName = "Alimentación" },
            new Opcion { Id = 58, OpcionName = "Educación" },
            new Opcion { Id = 59, OpcionName = "Transporte" },
            new Opcion { Id = 60, OpcionName = "Vivienda" },
            new Opcion { Id = 61, OpcionName = "Créditos" },
            new Opcion { Id = 62, OpcionName = "Seguros" },
            new Opcion { Id = 63, OpcionName = "Recreación y deportes" },
            new Opcion { Id = 64, OpcionName = "Flexibilidad (tiempo y lugar de trabajo)" }
            };

            return OpcionesTiempo;
        }




        private static List<Opcion> PreguntaPercepcion10()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                 new Opcion { Id = 88, OpcionName = "Proceso de on-boarding (selección, inducción y entrenamiento)"},
                 new Opcion { Id = 89, OpcionName = "Evaluación de desempeño"},
                 new Opcion { Id = 90, OpcionName = "Programas de Reconocimientos "},
                 new Opcion { Id = 91, OpcionName = "Oportunidades de crecimiento profesional (aprendizaje, formación y desarrollo)"},
                 new Opcion { Id = 92, OpcionName = "Habilidades complementarias (liderazgo, relacionamiento, otros) "},
                 new Opcion { Id = 93, OpcionName = "Programa de Bienestar "},
                 new Opcion { Id = 94, OpcionName = "Celebraciones especiales (día del padre, día de la madre, fin de año, otros)"}
            };
            return OpcionesTiempo;
        }

        private static List<Opcion> PreguntaPrioridades11()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                 new Opcion { Id = 95, OpcionName = "Declaración de renta o pago de impuestos"},
                new Opcion { Id = 96, OpcionName = "Contratación a terceros (asesorías laborales, jurídicas, o tributarias etc.)"},
                new Opcion { Id = 97, OpcionName = "Combustible o gastos por vehículo"},
                new Opcion { Id = 98, OpcionName = "Educación propia o para su pareja"},
                new Opcion { Id = 99, OpcionName = "Gastos de dependientes menores (educación, gastos menores, etc.)"},
                new Opcion { Id = 100, OpcionName = "Gastos en el cuidado de niños por parte de terceros"},
                new Opcion { Id = 101, OpcionName = "Gastos en el cuidado de la salud"},
                new Opcion { Id = 102, OpcionName = "Gastos por arriendo o mejoras de la casa"},
                new Opcion { Id = 103, OpcionName = "Recreación o gastos de viaje"},
                new Opcion { Id = 104, OpcionName = "Obligaciones crediticias (deudas)"},
                new Opcion { Id = 105, OpcionName = "Compra de vivienda principal"},
                new Opcion { Id = 106, OpcionName = "Gastos por el cuidado de personas mayores"},
                new Opcion { Id = 107, OpcionName = "Ninguna"}
            };
            return OpcionesTiempo;
        }


        private static List<Opcion> OpcionesEventos12()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 65, OpcionName = "Casarse o tener una relación permanente"},
                new Opcion { Id = 66, OpcionName = "Volver a estudiar a cualquier nivel"},
                new Opcion { Id = 67, OpcionName = "Ubicarse en otra ciudad"},
                new Opcion { Id = 68, OpcionName = "Esperar un hijo (a)/ etapa de embarazo"},
                new Opcion { Id = 69, OpcionName = "Adoptar un hijo (a)"},
                new Opcion { Id = 70, OpcionName = "Vivir con su hijo (a) la vida escolar por primera vez"},
                new Opcion { Id = 71, OpcionName = "Ser madre o padre soltero(a)"},
                new Opcion { Id = 72, OpcionName = "Experimentar una pérdida significativa de los ingresos del hogar"},
                new Opcion { Id = 73, OpcionName = "Cuidar dependientes adolescentes"},
                new Opcion { Id = 74, OpcionName = "Hacer de la salud o bienestar una prioridad crítica"},
                new Opcion { Id = 75, OpcionName = "Enviar a dependientes fuera de la ciudad "},
                new Opcion { Id = 76, OpcionName = "Divorciarse o separarse de su pareja"},
                new Opcion { Id = 77, OpcionName = "Tener problemas legales"},
                new Opcion { Id = 78, OpcionName = "Ser abuelo(a)"},
                new Opcion { Id = 79, OpcionName = "Cuidar un enfermo "},
                new Opcion { Id = 80, OpcionName = "Experimentar una enfermedad personal grave"},
                new Opcion { Id = 81, OpcionName = "Vivir la ausencia de un ser querido"},
                new Opcion { Id = 82, OpcionName = "Vivir la pérdida de trabajo de su cónyuge o compañero(a) permanente"},
                new Opcion { Id = 83, OpcionName = "Ser promovido(a)"},
                new Opcion { Id = 84, OpcionName = "Aumentar significativamente su carga de trabajo"},
                new Opcion { Id = 85, OpcionName = "Entrar en la etapa de retiro"},
                new Opcion { Id = 86, OpcionName = "Tener problemas financieros graves, deudas o créditos"},
                new Opcion { Id = 87, OpcionName = "Jubilarse o pensionarse"}
            };
            return OpcionesTiempo;
        }

        private static List<Opcion> OpcionPercepcion13()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 108, OpcionName = "Condiciones físicas del puesto de trabajo (oficina)"},
                new Opcion { Id = 109, OpcionName = "Opción de trabajo remoto (casa)"},
                new Opcion { Id = 110, OpcionName = "Equipo cómputo y conectividad (Google Meets, Zoom, Intranet)"},
                new Opcion { Id = 111, OpcionName = "Acceso a medios de transporte (rutas, movilización, vehículo)"},
                new Opcion { Id = 112, OpcionName = "Parqueadero en instalaciones"},
                new Opcion { Id = 113, OpcionName = "Zona de snack o café"},
                new Opcion { Id = 114, OpcionName = "Zona de lactancia"},
                new Opcion { Id = 115, OpcionName = "Salas de descanso"}
            };
            return OpcionesTiempo;
        }

        private static List<Opcion> OpcionConsideracion14()
        {
            var OpcionesTiempo = new List<Opcion>
            {
                new Opcion { Id = 117, OpcionName = "Tu Calidad de Vida"},
                new Opcion { Id = 118, OpcionName = "Tu Paquete Actual de Beneficios Monetarios y No Monetarios"},
                new Opcion { Id = 119, OpcionName = "Tu Desarrollo Personal y Profesional en tu actual Trabajo "},
                new Opcion { Id = 120, OpcionName = "Tus Herramientas de Trabajo"},
                new Opcion { Id = 121, OpcionName = "La Experiencia de Trabajo"}
            };
            return OpcionesTiempo;
        }


        private static List<Opcion> OpcionesLikkertper15()
        {

            var OpcionesLik = new List<Opcion> {
                new Opcion { Id = 1, OpcionName = "Mínimo: No se tiene ningún beneficio o los existentes son producto de disposiciones unilaterales o de acuerdos colectivos." },
                new Opcion { Id = 2, OpcionName = "Estable: Los beneficios están reglamentados en una política claramente definida que establece criterios de otorgamiento para que la administración sea equitativa." },
                new Opcion { Id = 3, OpcionName = "Foco en Costo: Se hace un análisis de beneficios en relación con su aprovechamiento interno. Se lleva un control detallado de los beneficios y se cuenta con indicadores que permiten entender el grado de utilización de los mismos." },
                new Opcion { Id = 4, OpcionName = "Foco en el Diseño: Se realiza un monitoreo permanente del mercado para incorporar toda oportunidad que pueda ser utilizada como beneficio(ejemplo: descuentos en establecimientos, convenios).Se hace una negociación con los proveedores con el fin de lograr economías de escala y mejores prestaciones del servicio." },
                new Opcion { Id = 5, OpcionName = "Foco en el Empleado (Alto impulso): Se cuenta con un programa de beneficios a la carta o flexibles, el cual genera la posibilidad al colaborador de escoger sus propios beneficios de acuerdo con su momento de vida y necesidades personales y familiares." },
            };

            return OpcionesLik;

        }

        private static List<Opcion> OpcionesLikkertper16()
        {

            var OpcionesLik = new List<Opcion> {
                new Opcion { Id = 1, OpcionName = "Menos del 5% de la nómina" },
                new Opcion { Id = 2, OpcionName = "5% al 10%" },
                new Opcion { Id = 3, OpcionName = "10% al 20%" },
                new Opcion { Id = 4, OpcionName = "20% al 30%" },
                new Opcion { Id = 5, OpcionName = "30% más" },
            };
            return OpcionesLik;
        }


        private static List<Pregunta> PreguntaCalidad1() {
            var Preguntas = new List<Pregunta>
            {
                new Pregunta {
                    NombrePregunta="¿Se reconoce la importancia del equilibrio entre la vida personal y laboral?",
                    TipoPregunta="Likkert",
                    NumeroPregunta=1,
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿La compañía hace esfuerzos por reducir trabajo innecesario?",
                    TipoPregunta="Likkert",
                    NumeroPregunta=2,
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Se espera que los trabajadores NO trabajen en horarios diferentes a los pactados (ejemplo: noches o fines de semana si es el caso)?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 3,
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Existe una política de calamidad doméstica?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 4, 
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Existen modalidades de trabajo flexible de una manera no tradicional (lugar, tiempo, etc.)?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 5, 
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Respeta las diferencias de sus empleados en términos de raza, género, religión, etc.?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 6,
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Constantemente le asigna actividades para cumplir en tiempos y plazos razonables?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 7, 
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="¿Valora la calidad de su trabajo más que la cantidad de tiempo que gasta en la oficina?",
                    TipoPregunta="Likkert",
                    NumeroPregunta = 8, 
                    Opciones=OpcionesLikkert1()},
                new Pregunta {
                    NombrePregunta="En cuál actividad emplea su tiempo libre? [Seleccione tantas como aplique]",
                    TipoPregunta="Selección Multiple",
                    NumeroPregunta=9,
                    Opciones=optionActividad2()},
                new Pregunta {
                    NombrePregunta="Cuáles de las siguientes acciones y recursos le ayudarían a tener mejor salud y mayor bienestar? (Seleccione tantas como aplique):",
                    TipoPregunta="Selección Multiple",
                    NumeroPregunta=10,
                    Opciones=optionAcciones3()},
                new Pregunta {
                    NombrePregunta="Cuánto tiempo promedio en horas al día consume en actividades domésticas (aseo, preparación de alimentos, otras labores etc.) antes y después de ir a trabajar",
                    TipoPregunta="Respuesta única",
                    NumeroPregunta=11,
                    Opciones=OpcionTiempo4()},
                new Pregunta {
                    NombrePregunta="Cuáles de los siguientes síntomas relacionados con su salud ha presentado",
                    TipoPregunta="Selección Multiple",
                    NumeroPregunta=12,
                    Opciones=OpcionSintomas5()},
                new Pregunta {
                    NombrePregunta="Con cuál de las siguientes situaciones o estados de ánimo se siente identificado(a)?",
                    TipoPregunta="Selección Multiple",
                    NumeroPregunta=13,
                    Opciones=OpcionAnimo6()},
                new Pregunta {
                    NombrePregunta="Con que frecuencia consume medicamentos para aliviar el estrés",
                    TipoPregunta="Respuesta única",
                    NumeroPregunta=14,
                    Opciones=OpcionMedicamento7()},
                //Revisar por que tiene opciones de opciones
                new Pregunta {
                    NombrePregunta="Con qué frecuencia consume las siguientes sustancias con el propósito de aliviar la ansiedad o el estrés",
                    TipoPregunta="Respuesta única",
                    NumeroPregunta=15,
                    Opciones=OpcionMedicamento8()}
            };
            return Preguntas;
            
        }

        private static List<Pregunta> PreguntaMonetarios2()
        {
            var Preguntas = new List<Pregunta>
            {
                 new Pregunta {
                     NombrePregunta="De la siguiente lista enumera de 1 a 10 tus necesidades personales y familiares, siendo 1 la más importante y 10 la menos importante. Por favor verifica que ningún aspecto tenga una calificación repetida y no dejes de llenar ningún aspecto",
                     NumeroPregunta=16,
                     TipoPregunta="Valoracion Multiple",
                     Opciones=OpcionesLista9()},
                 new Pregunta {
                     NombrePregunta="Evalúa los siguientes beneficios y facilitadores de vida actuales que le ofrece la Compañía (previo entendimiento de la compañía a diagnosticar). ",
                     NumeroPregunta=17,
                     TipoPregunta="Valoracion Multiple",
                     Opciones=null
                 },
                 new Pregunta {
                     NombrePregunta="¿Los beneficios son mejores que en la mayoría de las empresas del mercado?",
                     TipoPregunta="Abierta",
                     NumeroPregunta=18,
                     Opciones=null
                 },
                 new Pregunta {
                     NombrePregunta="¿La distribución de beneficios es equitativa?",
                     TipoPregunta="Abierta",
                     NumeroPregunta=19,
                     Opciones=null},

            };
            return Preguntas;
        }


        private static List<Pregunta> PreguntaDesarrollo3()
        {
            var Preguntas = new List<Pregunta>
            {
                 new Pregunta {
                     NombrePregunta="¿Cuál es su percepción sobre los siguientes aspectos?",
                     NumeroPregunta=20,
                     TipoPregunta="Likkert Multiple",
                     Opciones=PreguntaPercepcion10()},
                 new Pregunta {
                     NombrePregunta="¿Cuáles son sus tres (3) prioridades financieras o legales?",
                     NumeroPregunta=21,
                     TipoPregunta="Seleccion Multiple",
                     Opciones=PreguntaPrioridades11()
                 },
                 new Pregunta {
                     NombrePregunta="¿Cuáles de los siguientes eventos está experimentando o vislumbra va a experimentar en el siguiente año? (Seleccione tantos como aplique)?",
                     NumeroPregunta=22,
                     TipoPregunta="seleccion Multiple",
                     Opciones=OpcionesEventos12()
                 }
                 

            };
            return Preguntas;
        }

        private static List<Pregunta> PreguntaComplementarios4()
        {
            var Preguntas = new List<Pregunta>
            {
                 new Pregunta {
                     NombrePregunta="¿Cuál es su percepción sobre los siguientes aspectos?",
                     NumeroPregunta=23,
                     TipoPregunta="Multiple Likkert",
                     Opciones=OpcionPercepcion13()},
                 new Pregunta {
                     NombrePregunta="Tomando en consideración todos los componentes evaluados anteriormente, por favor califica tu nivel de percepción de los siguientes aspectos:",
                     NumeroPregunta=24,
                     TipoPregunta="Multiple Likkert",
                     Opciones=OpcionConsideracion14()}
            };
            return Preguntas;
        }


        private static List<Pregunta> PreguntaMercadeo5()
        {
            var Preguntas = new List<Pregunta>
            {
                 new Pregunta {
                     NombrePregunta="¿Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los beneficios?",
                      NumeroPregunta=25,
                     TipoPregunta="Multiple Likkert",
                     Opciones=OpcionesLikkertper15()
                 },
                 new Pregunta {NombrePregunta = "¿Cuánto gastó su empresa en total en beneficios en el último año fiscal?", NumeroPregunta = 26, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkertper16()},
                 new Pregunta {NombrePregunta = "¿Los empleados valoran su plan de beneficios?", NumeroPregunta = 27, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿El plan de beneficios mejora la atracción y retención?", NumeroPregunta = 28, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿El plan de beneficios mejora el compromiso del empleado con su trabajo?", NumeroPregunta = 29, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿El plan de beneficios moviliza el desempeño?", NumeroPregunta = 30, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta="¿Beneficios a la carta (escogencia de acuerdo con portafolio de productos)?", NumeroPregunta = 31, TipoPregunta = "Multiple Likkert",Opciones=OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Modelo de compensación flexible?", NumeroPregunta = 32, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {
                     NombrePregunta="¿Beneficio institucional (ej. Descuento en compra de productos de la compañía o entrega a cero costos?",
                     NumeroPregunta=33,
                     TipoPregunta="Multiple Likkert",
                     Opciones=OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Planes de ahorro contributivo?", NumeroPregunta = 34, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Pólizas de Seguros (Vida, Asistencia Médica Domiciliaria, otras)?", NumeroPregunta = 35, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta="¿Tiempo libre recompensado (día de cumpleaños, tarde libre los viernes, 24 / 31 diciembre y miércoles santo?" ,NumeroPregunta = 36, TipoPregunta = "Multiple Likkert",Opciones=OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Vacaciones colectivas?", NumeroPregunta = 37, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Servicio de restaurante y/o casino?", NumeroPregunta = 38, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Servicios fondos de empleados o cooperativa?", NumeroPregunta = 39, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Beneficios para el retiro?", NumeroPregunta = 40, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Beneficios pares el cuidado de la salud?", NumeroPregunta = 41, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Seguro de enfermedades críticas?", NumeroPregunta = 42, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Seguro de vida / muerte accidental?", NumeroPregunta = 43, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Beneficios por discapacidad?", NumeroPregunta = 44, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {NombrePregunta = "¿Seguro de mascotas?", NumeroPregunta = 45, TipoPregunta = "Multiple Likkert", Opciones = OpcionesLikkert1()},
                 new Pregunta {
                     NombrePregunta="¿Qué otros beneficios te gustarían incluir adicionales a los actuales ?",
                     NumeroPregunta=46,
                     TipoPregunta="Abierta",
                     Opciones=null},

            };
            return Preguntas;
        }

        public  static List<Category> Categories() {

            var categiras = new List<Category> {
                new Category{Id=1,NombreCategoria="Datos Demograficos",Preguntas=null},
                new Category{Id=2,NombreCategoria="Beneficios de Calidad de Vida",Preguntas=PreguntaCalidad1()},
                new Category{Id=3,NombreCategoria="Beneficios Monetarios y No Monetarios",Preguntas=PreguntaMonetarios2()},
                new Category{Id=4,NombreCategoria="Beneficios de Desarrollo Personal",Preguntas=PreguntaDesarrollo3()},
                new Category{Id=5,NombreCategoria="Beneficios en Herramientas de Trabajo",Preguntas=PreguntaComplementarios4()},
                new Category{Id=6,NombreCategoria="Beneficios/Madurez",Preguntas=PreguntaMercadeo5()}

            };
            return categiras;
        }


    }
}

