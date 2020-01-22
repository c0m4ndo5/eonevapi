using System;
using System.Linq;
using System.Collections.Generic;
using eonevapi.api.Mapping;
using eonevapi.api.Resources;
using eonevapi.core.Models;
using Xunit;

namespace eonevapi.api.test
{
    public class TestMapper
    {
        [Fact]
        public void TestBasic()
        {
            EventResourceMapper mapper = new EventResourceMapper();
            Event e = new Event()
            {
                id = "x",
                title = "test",
                categories = new List<Category>(){
                    new Category(){
                        id=1
                    }
                },
                geometries = new List<Geometry>(){
                    new Geometry(){
                        date=DateTime.Now,
                        coordinates= new List<object>(){
                            "20","30"
                        }
                    }
                }
            };
            EventResource result = mapper.mapToResource(e);
            Assert.Equal("x", result.id);
            Assert.Equal("test", result.title);
            Assert.Equal(1, result.categoryId);
            Assert.Equal(20, result.lastGeometryX);
            Assert.Equal(30, result.lastGeometryY);
            Assert.Null(result.closed);
        }

        [Fact]
        public void testList()
        {
            EventResourceMapper mapper = new EventResourceMapper();
            Event e = new Event()
            {
                id = "x",
                title = "test",
                categories = new List<Category>(){
                    new Category(){
                        id=1
                    }
                },
                geometries = new List<Geometry>(){
                    new Geometry(){
                        date=DateTime.Now,
                        coordinates= new List<object>(){
                            "20","30"
                        }
                    }
                }
            };
            List<Event> events = new List<Event>() { e, e };
            var result = mapper.mapToResourceList(events);
            Assert.Equal(2, result.Count());
        }


    }
}
