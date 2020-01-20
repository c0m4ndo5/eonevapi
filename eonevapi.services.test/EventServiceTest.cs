using System;
using Xunit;
using eonevapi.services;
using eonevapi.services.test.Mock;
using System.Collections.Generic;
using System.Linq;
using eonevapi.core.Models;
using System.Threading.Tasks;
using eonevapi.core.QueryOptions;

namespace eonevapi.services.test
{
    public class EventServiceTest
    {
        EventService init()
        {
            List<Event> mockData = new List<Event>();
            mockData = new List<Event>(){
                new Event(){
                    id="EONET-1",
                    categories=new List<Category>(){
                        new Category(){
                            id=1,
                            title="A"
                        }
                    },
                    geometries = new List<Geometry>(){
                        new Geometry(){
                            date = DateTime.Now
                        }
                    }
                },
                new Event(){
                    id="EONET-3",
                    categories=new List<Category>(){
                        new Category(){
                            id=1,
                            title="A"
                        }
                    },
                    geometries = new List<Geometry>(){
                        new Geometry(){
                            date = DateTime.Now.AddDays(-5)
                        }
                    }
                },
                new Event(){
                    id="EONET-2",
                    categories=new List<Category>(){
                        new Category(){
                            id=1,
                            title="A"
                        }
                    },
                    geometries = new List<Geometry>(){
                        new Geometry(){
                            date = DateTime.Now.AddDays(-30)
                        }
                    },
                    closed=DateTime.Now.AddDays(-25)
                },
                new Event(){
                    id="EONET-4",
                    categories=new List<Category>(){
                        new Category(){
                            id=3,
                            title="B"
                        }
                    },
                    geometries = new List<Geometry>(){
                        new Geometry(){
                            date = DateTime.Now
                        }
                    }
                },
                new Event(){
                    id="EONET-5",
                    categories=new List<Category>(){
                        new Category(){
                            id=2,
                            title="C"
                        }
                    },
                    geometries = new List<Geometry>(){
                        new Geometry(){
                            date = DateTime.Now.AddDays(-1)
                        }
                    }
                }
            };
            MockUnitOfWork mockUnitOfWork = new MockUnitOfWork(null, mockData);
            return new EventService(mockUnitOfWork);
        }
        [Fact]
        public async Task GetAllTest()
        {
            EventService service = init();
            var result = await service.GetAllEvents();
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task GetByIdTest()
        {
            EventService service = init();
            var result = await service.GetById("EONET-1");

            Assert.Equal("EONET-1", result.id);

            var none = await service.GetById("none");
            Assert.Null(none);
        }

        [Fact]
        public async Task GetFilteredBasic()
        {
            EventService service = init();
            var result = await service.GetFiltered(new EventQueryOptions());
            //Running without any options should return everything
            Assert.Equal(5, result.Count());
        }

        [Fact]
        public async Task GetFilteredOrderingTest()
        {
            //Filtering is done by EONET - ordering is done by the code and must be tested
            EventService service = init();
            var result = await service.GetFiltered(new EventQueryOptions()
            {
                SortingOptions =
                    new OrderingOptions()
                    {
                        OrderingOption = EventOrderingOptions.OrderByCategory,
                        Direction = OrderingDirection.DESC
                    }

            });

            Assert.Equal("EONET-4", result.ElementAt(0).id);

            result = await service.GetFiltered(new EventQueryOptions()
            {
                SortingOptions =
                    new OrderingOptions()
                    {
                        OrderingOption = EventOrderingOptions.OrderByStatus,
                        Direction = OrderingDirection.ASC
                    }

            });

            Assert.Equal("EONET-2", result.ElementAt(0).id);

            result = await service.GetFiltered(new EventQueryOptions()
            {
                SortingOptions =
                    new OrderingOptions()
                    {
                        OrderingOption = EventOrderingOptions.OrderByDate,
                        Direction = OrderingDirection.ASC
                    }

            });

            Assert.Equal("EONET-2", result.ElementAt(0).id);
        }

        [Fact]
        public async Task TestMultiOptions()
        {
            EventService service = init();
            var result = await service.GetFiltered(new EventQueryOptions()
            {
                SearchEnd = DateTime.Now.AddDays(-2),
                SortingOptions =
                    new OrderingOptions()
                    {
                        OrderingOption = EventOrderingOptions.OrderByCategory,
                        Direction = OrderingDirection.DESC
                    }

            });

            Assert.Equal("EONET-2", result.ElementAt(0).id);
        }
    }
}