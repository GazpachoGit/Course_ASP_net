import $ from 'jquery';

var filteredEvents = [];

var selectedCities = [];
var selectedVenues = [];
var selectedDateFrom;
var selectedDateTo;
var selectedName;
var selectedSortBy;
var selectedSortOrder;
var selectedPage = 1;
var selectedPageSize = 2;

var filterCity ={
    cityName: null,
};
var filterVenue ={
    venueName: null,
    cities: selectedCities.map(i  => i.value)
};
var filterEvent = {
    name: selectedName,
    dateFrom: selectedDateFrom,
    dateTo: selectedDateTo,
    cities: selectedCities.map(i  => i.value),
    venues: selectedVenues.map(i => i.value),
    sortBy: selectedSortBy,
    sortOrder: selectedSortOrder,
    page: selectedPage,
    pageSize: selectedPageSize
};

var sortArrows = {
    Asc: 'fa fa-angle-up',
    Desc: 'fa fa-angle-down'
};

Object.defineProperty(filterVenue, 'cities', { get: () => { return  selectedCities.map(i  => i.value)} });

Object.defineProperty(filterEvent, 'name', { get: () => { return  selectedName;} });
Object.defineProperty(filterEvent, 'cities', { get: () => { return  selectedCities.map(i  => i.value)} });
Object.defineProperty(filterEvent, 'venues', { get: () => { return  selectedVenues.map(i => i.value)} });
Object.defineProperty(filterEvent, 'dateFrom', { get: () => { return  selectedDateFrom;} });
Object.defineProperty(filterEvent, 'sortBy', { get: () => { return  selectedSortBy;} });
Object.defineProperty(filterEvent, 'sortOrder', { get: () => { return  selectedSortOrder;} });
Object.defineProperty(filterEvent, 'page', { get: () => { return  selectedPage;} });
Object.defineProperty(filterEvent, 'pageSize', { get: () => { return  selectedPageSize;} });

function setCity(cityName) {
    $('#cityList').find('li').remove();
    filterCity.cityName = cityName;
    $.ajax({
        url: `/api/v1/City`,
        traditional: true,
        data: filterCity,
        success: (data, status, xhr) => {
            data.forEach(element => {
                if (!selectedCities.some(item => item.value == element.cityId)) {
                    $('#cityList').append($('<li>').attr('value', element.cityId).text(element.name).addClass('list-group-item'));
                }               
            });           
        }    
    });
}

function setVenue() {
    $('#venueList').find('li').remove();    
    $.ajax({
        url: `/api/v1/Venue`,
        traditional: true,
        data: filterVenue,
        success: (data, status, xhr) => {
            data.forEach(element => {
                if (!selectedVenues.some(item => item.value == element.id)) {
                    $('#venueList').append($('<li>').attr('value', element.id).text(element.name).addClass('list-group-item'));
                }              
            });           
        }    
    });
}

function searchEvent(selectFirstPage) {
    if (selectFirstPage) {
        selectedPage = 1;
    }
    console.log(filterEvent);
    $.ajax({
        url: `/api/v1/Event`,
        traditional: true,
        data: filterEvent,
        success: (data, status, xhr) => {
            setEvents(data);
            const count = xhr.getResponseHeader('x-total-count');
            setPages(selectedPage, count, selectedPageSize);
        }
    });    
}
function setEvents(data) {
    $(".event-items-container").empty();
    filteredEvents = [];
    if (data && data.length > 0) {
        data.forEach(event => {
            filteredEvents.push(event);
            var item = `<div class="event-cart-item">
                            <div>
                                <h5 class="title">${event.name}</h5>
                                <p class="text">${event.date}</p>
                                <p>${event.venue.name}<p>
                                <p>${event.cityName}<p>
                                <div class="d-flex justify-content-center">
                                    <a href="#" class="btn btn-primary btn-block">Tickets</a>
                                </div>             
                            </div>
                        </div>`;

            $(".event-items-container").append(item);       
        });
    } else {
        $(".event-items-container").append('<h3>No data found</h3>');
    }   
}
function setEventList(name) {   
    $('#nameEvent').find('option').remove();
    $.ajax({
        url: `/api/v1/Event/filterByName`,
        traditional: true,
        data: {eventName: name},
        success: (data, status, xhr) => {
            data.forEach(element => {
                    $('#nameEvent').append($('<option>').attr('value', element).addClass('list-group-item'));                             
            });           
        }
    })   
}
function setPages(selectedPage, count, selectedPageSize) {
    const pageCount = Math.ceil(count / selectedPageSize);
         const buttons = [];
         for (let i = 1; i <= pageCount; i++) {
             const button = $('<li>', { class: 'page-item' });
             if (i == selectedPage) {
                 button.append($('<a>').addClass("page-link text-success border border-success").text(i));
            } else {
                button.append($('<a>').addClass("page-link text-success").text(i));
             }
              buttons.push(button);
          }
         $('.pageBar').empty().append(buttons);
}

$(document).ready(function () {
    setCity();
    setVenue();
    searchEvent();

    //city
    $('#cityEvent').on('change', (e) => {
        var cityName = e.target.value;
        setCity(cityName);
    });
    $('#cityList').on('click', 'li', (e) => {
        selectedCities.push({value: e.target.value, text: e.target.textContent});
        $('#cityListSelected').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action bg-laf'));
        $('#cityList').find(e.target).remove();
    });

    $('#cityListSelected').on('click', 'li', (e) => {
        selectedCities = selectedCities.filter(item => item.value != e.target.value);
        $('#cityList').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action'));
        $('#cityListSelected').find(e.target).remove();
    });
    //venue
    $('#cityListSelected').on('DOMSubtreeModified', (e) => {
        console.log(e);
        setVenue();
        searchEvent(1);
    });
    $('#venueList').on('click', 'li', (e) => {
        selectedVenues.push({value: e.target.value, text: e.target.textContent});
        $('#venueListSelected').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action bg-laf'));
        $('#venueList').find(e.target).remove();
        searchEvent(1);
    });
    $('#venueListSelected').on('click', 'li', (e) => {
        selectedVenues = selectedVenues.filter(item => item.value != e.target.value);
        $('#venueList').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action'));
        $('#venueListSelected').find(e.target).remove();
        searchEvent(1);
    });
    $('#venueEvent').on('change', (e) => {
        filterVenue.venueName = e.target.value;
        setVenue();
    });
    //date
    $('#dateEventFrom').on('change', (e) => {
        selectedDateFrom = e.target.value;
        console.log(selectedDateFrom);
        searchEvent(1);
    });
    $('#dateEventTo').on('change', (e) => {
        if(selectedDateFrom && selectedDateFrom > e.target.value) {
            $('#dateEventTo').css('border-color', 'red');
        } else {
            $('#dateEventTo').css('border-color', '');
            selectedDateTo = e.target.value;
            console.log(selectedDateTo);
        }
        searchEvent(1);
        
    });
    $('#searchEvent').on('click', () => {
        searchEvent(1);
    });
    $('#clearEvent').on('click', () => {
        //$('#searchBar').val('');
        //selectedName = null;

        selectedCities = [];
        selectedVenues = [];
        $('#venueListSelected').find('li').remove();
        $('#cityListSelected').find('li').remove();
        setCity();

        $('#dateEventTo').val('');
        $('#dateEventFrom').val('');
        selectedDateFrom = undefined;
        selectedDateTo = undefined;

        searchEvent(1);  
    });
    $('#searchBar').on('change', (e) => {
        $( "#clearEvent" ).trigger( "click" );
        selectedName = e.target.value;
        searchEvent(1);
    })   
    $("#searchBar").keyup(function(e){
        if(e.keyCode != 8){ 
         var value = this.value;
         setEventList(value);
         }
      });
    //sort
    $('.sortOpt').on('change', (e) => {
        var sorting = $('.sortOpt').find(':selected')[0];
        selectedSortBy = sorting.attributes.sortby.value;
        selectedSortOrder = sorting.attributes.sortdir.value;
        searchEvent();        
    })
    //pages
    $('.pageBar').on('click','a', (e) => {
        selectedPage = e.target.text;
        console.log(selectedPage);
        searchEvent();
    })
    $('.page-size').on('change', (e) => {
        console.log(e);
        selectedPageSize = $(this).find(':selected').val();
        searchEvent();
    });
    
});


