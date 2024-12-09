const FORM_FIELD_IDS = {
    matchId: "MatchId",
    teamId: "TeamId",
    corners: "Corners",
    possesion: "Possession",
    scoredCXBID: "Scored",
    playerId: "PlayerId",
    scoredMinute: "Minute",
    goalType: "GoalType",
    cardIssuedCXBID: "Card-Issued",
    cardPlayerId: "CardPlayerId",
    cardIssuedMinute: "CardIssuedMinute",
    cardType: "CardType",
    reason: "Reason",
}

const matchStatisticsForm = document.getElementById("match-statistics-form");
const goalsForm = document.getElementById("goals-form");
const cardsForm = document.getElementById("cards-form");

const goalsFormSection = document.getElementById("goals-form-section")
const cardsFormSection = document.getElementById("cards-form-section")

const matchIdInput = document.getElementById(FORM_FIELD_IDS.matchId);
const teamIdInput = document.getElementById(FORM_FIELD_IDS.teamId);

const goalPlayerIdInput = document.getElementById(FORM_FIELD_IDS.playerId);
const scoredMinuteInput = document.getElementById(FORM_FIELD_IDS.scoredMinute);
const goalTypeInput = document.getElementById(FORM_FIELD_IDS.goalType);

const cardPlayerIdInput = document.getElementById(FORM_FIELD_IDS.cardPlayerId);
const cardIssuedMinInput = document.getElementById(FORM_FIELD_IDS.cardIssuedMinute);
const cardTypeInput = document.getElementById(FORM_FIELD_IDS.cardType);
const cardReasonInput = document.getElementById(FORM_FIELD_IDS.reason);

const scoredCXB = document.getElementById(FORM_FIELD_IDS.scoredCXBID);
const cardIssuedCXB = document.getElementById(FORM_FIELD_IDS.cardIssuedCXBID);

const goalHtmlSection = document.getElementById("goal-list-display");
const cardHtmlSection = document.getElementById("card-list-display");

const goalsList = [];
const cardsList = [];

console.log(matchStatisticsForm)
console.log(scoredCXB)
console.log(cardIssuedCXB)

const mainFormSubmitHandler = async (event) => {
    event.preventDefault();
    console.log(event)
    console.log(event.target[FORM_FIELD_IDS.possesion].value)

    const body = {
        MatchId: matchIdInput.value,
        TeamId: teamIdInput.value,
        Corners: event.target[FORM_FIELD_IDS.corners].value,
        Posession: event.target[FORM_FIELD_IDS.possesion].value,
        Goals: goalsList.length >= 0 ? goalsList : null,
        Cards: cardsList.length >= 0 ? cardsList : null,
    }

    console.log(body)
    console.log(JSON.stringify(body))

    const response = await fetch(`${BASE_APP_PATH}/admin/matchstatistics/create`, {
        method: "POST",
        body: JSON.stringify(body),
        headers: { "Content-Type": "application/json", }
    })

    if (!response.ok) {
        console.log("response is not ok")
        const errorData = response.json();
        console.log(errorData)
        // handle errors
        return
    }

    console.log("response is ok")
    //handle successfull fetch
    var data = await response.json()
    console.log(data);

}


const goalFormSubmitHandler = (event) => {
    event.preventDefault();
    const goal = {
        MatchId: matchIdInput.value,
        TeamId: teamIdInput.value,
        PlayerId: event.target[FORM_FIELD_IDS.playerId].value,
        Minute: event.target[FORM_FIELD_IDS.scoredMinute].value,
        GoalType: event.target[FORM_FIELD_IDS.goalType].value,
    };

    goalsList.push(goal)

    const selectedPlayer = goalPlayerIdInput.options[goalPlayerIdInput.selectedIndex].text;
    const selectedGoalType = goalTypeInput.options[goalTypeInput.selectedIndex].text

    console.log(goalHtmlSection.innerHTML);

    goalHtmlSection.innerHTML += `
    <tr>
    <td>${selectedPlayer}</td>
    <td>${goal.Minute}</td>
    <td>${selectedGoalType}</td>
    </tr>
    `

    console.log(goalsList);

}

const cardFormSubmitHandler = (event) => {
    event.preventDefault();
    const card = {
        MatchId: matchIdInput.value,
        TeamId: teamIdInput.value,
        PlayerId: event.target[FORM_FIELD_IDS.cardPlayerId].value,
        IssuedMinute: event.target[FORM_FIELD_IDS.cardIssuedMinute].value,
        CardType: event.target[FORM_FIELD_IDS.cardType].value,
        Reason: event.target[FORM_FIELD_IDS.reason].value
    };

    cardsList.push(card)

    const selectedPlayer = cardPlayerIdInput.options[cardPlayerIdInput.selectedIndex].text;
    const selectedCardType = cardTypeInput.options[cardTypeInput.selectedIndex].text;

    cardHtmlSection.innerHTML += `
         <tr>
    <td>${selectedPlayer}</td>
    <td>${card.IssuedMinute}</td>
    <td>${selectedCardType}</td>
    <td>${card.Reason}</td>
    </tr>
    `
}

const scoreCeckboxChangeHandler = (event) => {
    if (event.target.checked) {
        goalsFormSection.classList.remove("hide")
    } else {
        goalsFormSection.classList.add("hide");
    }
}

const cardIssuedCheckboxChangeHandler = (event) => {
    if (event.target.checked) {
        cardsFormSection.classList.remove("hide")
    } else {
        cardsFormSection.classList.add("hide");
    }
}

matchStatisticsForm.addEventListener("submit", mainFormSubmitHandler);
goalsForm.addEventListener("submit", goalFormSubmitHandler);
cardsForm.addEventListener("submit", cardFormSubmitHandler);
scoredCXB.addEventListener("change", scoreCeckboxChangeHandler);
cardIssuedCXB.addEventListener("change", cardIssuedCheckboxChangeHandler);