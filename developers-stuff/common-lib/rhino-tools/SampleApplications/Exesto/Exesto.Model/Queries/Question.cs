﻿#region license
// Copyright (c) 2005 - 2007 Ayende Rahien (ayende@ayende.com)
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
//     * Redistributions of source code must retain the above copyright notice,
//     this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright notice,
//     this list of conditions and the following disclaimer in the documentation
//     and/or other materials provided with the distribution.
//     * Neither the name of Ayende Rahien nor the names of its
//     contributors may be used to endorse or promote products derived from this
//     software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
// FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
// OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
// THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Query {
    
    
    public partial class Where {
        
        static Root_Query_Question _root_query_Question = new Root_Query_Question();
        
        public static Root_Query_Question Question {
            get {
                return _root_query_Question;
            }
        }
        
        public partial class Query_Question<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_Question(string name, string assoicationPath) : 
                    base(name, assoicationPath) {
            }
            
            public Query_Question(string name, string assoicationPath, bool backTrackAssoicationOnEquality) : 
                    base(name, assoicationPath, backTrackAssoicationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Content {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Content", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Title {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Title", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Answer {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Answer", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> Id {
                get {
                    string temp = assoicationPath;
                    return new Query.QueryBuilder<T1>("Id", temp);
                }
            }
            
            public virtual Query_Subject<T1> Subject {
                get {
                    string temp = assoicationPath;
                    temp = ((temp + ".") 
                                + "Subject");
                    return new Query_Subject<T1>("Subject", temp, true);
                }
            }
        }
        
        public partial class Root_Query_Question : Query_Question<Exesto.Model.Question> {
            
            public Root_Query_Question() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class Question {
            
            public static Query.OrderByClause Content {
                get {
                    return new Query.OrderByClause("Content");
                }
            }
            
            public static Query.OrderByClause Title {
                get {
                    return new Query.OrderByClause("Title");
                }
            }
            
            public static Query.OrderByClause Answer {
                get {
                    return new Query.OrderByClause("Answer");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class Question {
            
            public static Query.PropertyProjectionBuilder Content {
                get {
                    return new Query.PropertyProjectionBuilder("Content");
                }
            }
            
            public static Query.PropertyProjectionBuilder Title {
                get {
                    return new Query.PropertyProjectionBuilder("Title");
                }
            }
            
            public static Query.PropertyProjectionBuilder Answer {
                get {
                    return new Query.PropertyProjectionBuilder("Answer");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class Question {
            
            public static NHibernate.Expression.IProjection Content {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Content");
                }
            }
            
            public static NHibernate.Expression.IProjection Title {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Title");
                }
            }
            
            public static NHibernate.Expression.IProjection Answer {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Answer");
                }
            }
        }
    }
}
