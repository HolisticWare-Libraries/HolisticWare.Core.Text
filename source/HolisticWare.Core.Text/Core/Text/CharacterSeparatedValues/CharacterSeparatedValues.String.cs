using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                        (
                                                            char column_delimiter,
                                                            string row_delimiter
                                                        )
        {
            return this.ParseUsingString(column_delimiter, row_delimiter);
        }

        public Type ContainedType
        {
            get;
            set;
        }

        /// <summary>
        /// Temporary implementation with (string) array of lines
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        public IEnumerable<IEnumerable<string>> Parse(string[] lines)
        {
            return this.ParseTemporaryImplementationWithLines(lines);
        }

        /// <summary>
        /// Temporary implementation with (string) array of lines
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private IEnumerable<IEnumerable<string>> ParseTemporaryImplementationWithLines(string [] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                IEnumerable<string> lines_from_parameter = lines[i].Split
                    (
                    SeparatorsNewLine, 
                    StringSplitOptions.RemoveEmptyEntries
                    );

                for (int j = 0; j < lines_from_parameter.Count(); j++)
                {
                    IEnumerable<string> columns = lines_from_parameter.ElementAt(j).Split
                        (
                        Separators, 
                        StringSplitOptions.RemoveEmptyEntries
                        );
                    yield return columns;
                }
            }
        }

        public IEnumerable<IEnumerable<string>> Parse()
        {
            return this.ParseTemporaryImplementation();
        }

        public IEnumerable<IEnumerable<string>> ParseTemporaryImplementation()
                        // // Error CS0702: Constraint cannot be special class 'ValueType'         
                        // where T : ValueType
        {
            IEnumerable<string> lines = Text.Split
                                        (
                                            SeparatorsNewLine,
                                            StringSplitOptions.RemoveEmptyEntries
                                        );
            foreach (string line in lines)
            {
                IEnumerable<string> columns = line.Split
                                        (
                                            Separators,
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

                    yield return columns;
            }

            //for (int i = 0; i < lines.Length; i++)
            //{
            //    string[] columns = lines[i].Split
            //                            (
            //                                Separators,
            //                                StringSplitOptions.RemoveEmptyEntries
            //                            );

            //    yield return columns;
            //}
        }

        public delegate IEnumerable<T> TransformationMethod<T>(IEnumerable<string[]> untyped_data);

        protected TransformationMethod<string[]> TransformationDefault;

        public IEnumerable<string[]> Transformation(IEnumerable<string[]> untyped_data)
        {
            return untyped_data;
        }
    }
}