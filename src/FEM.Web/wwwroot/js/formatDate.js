const padZ = (value) => {
    return value < 10 ? `0${value}` : `${value}`;
};

const formatDate = (date, showHour) => {
    let month = date.getMonth() + 1;
    let day = date.getDate();
    let stringDate = `${date.getFullYear()}-${padZ(month)}-${padZ(day)}`;

    if (!showHour) return stringDate;

    const hour = date.toLocaleTimeString(undefined, {
        hour: "2-digit",
        minute: "2-digit",
    });

    return stringDate + " " + hour;
};


const formatHour = (dateTime) => {
    return dateTime.toLocaleTimeString(undefined, {
        hour: "2-digit",
        minute: "2-digit",
    })
}