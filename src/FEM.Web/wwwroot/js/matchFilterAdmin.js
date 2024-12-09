const form = document.getElementById("match-filter-form");
const nameInput = document.getElementById("search-input");
const liveMatchesInput = document.getElementById("live-matches");
const startDateInput = document.getElementById("startDate");
const endDateInput = document.getElementById("endDate");
const sortTypeInput = document.getElementById("sort-type");
const submitBtn = document.getElementById("match-filter-sbt");
const matchesSection = document.getElementById("matches-list");


startDateInput.value = formatDate(new Date(), false)

const onFormSubbmitHandler = async (event) => {
    event.preventDefault()
    console.log(nameInput.value)

    const response = await fetch(`${BASE_APP_PATH}/matches/filter?std=${startDateInput.value}&edt=${endDateInput.value}&lm=${liveMatchesInput.checked}&st=${sortTypeInput.value}&tname=${nameInput.value}`)
    const resData = await response.json();

    if (resData.length < 1) {
        matchesSection.innerHTML = `<p>Cannot find matches on ${formatDate(new Date(startDateInput.value))}</p>`
        return;
    }

    let htmlMatches = ` `
    resData.forEach(x =>

        htmlMatches += `
        <div class="match">
            <div>${x.team1.name}</div>
            <div>${formatDate(new Date(x.date), true)}</div>
            <div>${x.team2.name}</div>

             <div style="display:flex;">
            <p>${x.status}</p>
              <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#changeStatusModal" data-bs-matchId="${x.id}">
                Change Status
            </button>
            </div>
            
            <a href="${BASE_APP_PATH}/matches/createDetails/${x.id}">Add Statistics</a>
            <a href="${BASE_APP_PATH}/matches/createDetails/${x.id}">Add Statistics</a>
        </div>  `
    )

    matchesSection.innerHTML = htmlMatches
    console.log(htmlMatches);
    console.log(resData);
}

const teamNameChangeHandler = async (event) => {
    const name = event.target.value;
    console.log(event)
    if (name.length < 3) {
        return
    }

    const response = await fetch(`${BASE_APP_PATH}/matches/team?teamName=${name}`)
    const resData = await response.json();

    if (resData.length < 1) {
        matchesSection.innerHTML = `<p>Cannot find matches for ${name}</p>`
        return;
    }

    let htmlMatches = ` `
    resData.forEach(x =>

        htmlMatches += `
        <div class="match">
            <div>${x.team1.name}</div>
            <div>${formatDate(new Date(x.date), true)}</div>
            <div>${x.team2.name}</div>
            <a href="${BASE_APP_PATH}/matches/details/${x.id}">Details</a>
        </div>  `
    )

    matchesSection.innerHTML = htmlMatches
}

const liveMatchesChangeHandler = (event) => {
    const value = event.target.value;

    submitBtn.click()
}

const startDateChangeHandler = (event) => {

    submitBtn.click()
}

const endDateChangeHandler = (event) => {

    submitBtn.click()
}

const sortTypeChangeHandler = (event) => {

    submitBtn.click()
}

form.addEventListener("submit", onFormSubbmitHandler);
nameInput.addEventListener("keyup", teamNameChangeHandler)
liveMatchesInput.addEventListener("change", liveMatchesChangeHandler)
startDateInput.addEventListener("change", startDateChangeHandler)
endDateInput.addEventListener("change", endDateChangeHandler)
sortTypeInput.addEventListener("change", sortTypeChangeHandler)