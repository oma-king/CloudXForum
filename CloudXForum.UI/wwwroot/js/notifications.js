let notificationListArray = [];

function updateNotificationCount() {
    document.getElementById('notificationCount').innerText = notificationListArray.length.toString();
}

function populateNotificationList() {
    const notificationListContainer = document.getElementById('notificationList');
    notificationListContainer.innerHTML = '';

    notificationListArray.forEach(notification => {
        const notificationItem = document.createElement('li');
        //notificationItem.classList.add('dropdown-item');
        notificationItem.classList.add('nav-item');
        notificationItem.href = '#';
        notificationItem.innerHTML = `
            <form id="markAsReadForm_${notification.id}" asp-controller="Home" asp-action="MarkAsRead" asp-route-repliesfollowupid="${notification.id}" method="post">
            <table><tbody><tr><td><span class="material-symbols-outlined" onclick="markAsRead(${notification.id})">mark_email_read</span></td>
            <td>New <a href="/Post/Index/${notification.postId}" onclick="markAsRead(${notification.id})">reply</a> "<i>${notification.content.slice(0, 15)}${notification.content.length > 15 ? '...' : ''}</i>" on post <strong>${notification.title}</strong> by ${notification.userName}</td>
            </tr></tbody></table></form>
        `;
        notificationListContainer.appendChild(notificationItem);
        const notificationdivider = document.createElement('div');
        notificationdivider.classList.add('dropdown-divider');
        notificationListContainer.appendChild(notificationdivider);
    });
}

function markAsRead(notificationId) {
    $.ajax({
        url: `/Home/MarkAsRead?repliesFollowupId=${notificationId}`,
        type: 'POST',
        success: function () {
            updateNotifications();
        },
        error: function (error) {
            console.error('Error marking as read:', error);
        }
    });
}

function updateNotifications() {
    fetch('/Home/GetUpdatedNotifications', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => response.json())
        .then(data => {
            notificationListArray = data;
            updateNotificationCount();
            populateNotificationList();
        })
        .catch(error => {
            console.error('Error fetching notifications:', error);
        });
}

setInterval(updateNotifications, 5000);
updateNotifications();
