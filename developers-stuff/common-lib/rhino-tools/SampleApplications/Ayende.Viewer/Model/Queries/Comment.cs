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
        
        static Root_Query_Comment _root_query_Comment = new Root_Query_Comment();
        
        public static Root_Query_Comment Comment {
            get {
                return _root_query_Comment;
            }
        }
        
        public partial class Query_Comment<T1> : Query.QueryBuilder<T1>
         {
            
            public Query_Comment(string name, string assoicationPath) : 
                    base(name, assoicationPath) {
            }
            
            public Query_Comment(string name, string assoicationPath, bool backTrackAssoicationOnEquality) : 
                    base(name, assoicationPath, backTrackAssoicationOnEquality) {
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Created {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Created", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Modified {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Modified", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Author {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Author", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Email {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Email", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> HomePage {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("HomePage", temp);
                }
            }
            
            public virtual Query.PropertyQueryBuilder<T1> Content {
                get {
                    string temp = assoicationPath;
                    return new Query.PropertyQueryBuilder<T1>("Content", temp);
                }
            }
            
            public virtual Query.QueryBuilder<T1> CommentId {
                get {
                    string temp = assoicationPath;
                    return new Query.QueryBuilder<T1>("CommentId", temp);
                }
            }
            
            public virtual Query_Post<T1> Post {
                get {
                    string temp = assoicationPath;
                    temp = ((temp + ".") 
                                + "Post");
                    return new Query_Post<T1>("Post", temp, true);
                }
            }
        }
        
        public partial class Root_Query_Comment : Query_Comment<Model.Comment> {
            
            public Root_Query_Comment() : 
                    base("this", null) {
            }
        }
    }
    
    public partial class OrderBy {
        
        public partial class Comment {
            
            public static Query.OrderByClause Created {
                get {
                    return new Query.OrderByClause("Created");
                }
            }
            
            public static Query.OrderByClause Modified {
                get {
                    return new Query.OrderByClause("Modified");
                }
            }
            
            public static Query.OrderByClause Author {
                get {
                    return new Query.OrderByClause("Author");
                }
            }
            
            public static Query.OrderByClause Email {
                get {
                    return new Query.OrderByClause("Email");
                }
            }
            
            public static Query.OrderByClause HomePage {
                get {
                    return new Query.OrderByClause("HomePage");
                }
            }
            
            public static Query.OrderByClause Content {
                get {
                    return new Query.OrderByClause("Content");
                }
            }
        }
    }
    
    public partial class ProjectBy {
        
        public partial class Comment {
            
            public static Query.PropertyProjectionBuilder Created {
                get {
                    return new Query.PropertyProjectionBuilder("Created");
                }
            }
            
            public static Query.PropertyProjectionBuilder Modified {
                get {
                    return new Query.PropertyProjectionBuilder("Modified");
                }
            }
            
            public static Query.PropertyProjectionBuilder Author {
                get {
                    return new Query.PropertyProjectionBuilder("Author");
                }
            }
            
            public static Query.PropertyProjectionBuilder Email {
                get {
                    return new Query.PropertyProjectionBuilder("Email");
                }
            }
            
            public static Query.PropertyProjectionBuilder HomePage {
                get {
                    return new Query.PropertyProjectionBuilder("HomePage");
                }
            }
            
            public static Query.PropertyProjectionBuilder Content {
                get {
                    return new Query.PropertyProjectionBuilder("Content");
                }
            }
        }
    }
    
    public partial class GroupBy {
        
        public partial class Comment {
            
            public static NHibernate.Expression.IProjection Created {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Created");
                }
            }
            
            public static NHibernate.Expression.IProjection Modified {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Modified");
                }
            }
            
            public static NHibernate.Expression.IProjection Author {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Author");
                }
            }
            
            public static NHibernate.Expression.IProjection Email {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Email");
                }
            }
            
            public static NHibernate.Expression.IProjection HomePage {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("HomePage");
                }
            }
            
            public static NHibernate.Expression.IProjection Content {
                get {
                    return NHibernate.Expression.Projections.GroupProperty("Content");
                }
            }
        }
    }
}
