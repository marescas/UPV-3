FROM zmq
RUN mkdir /zmq
COPY ./newclient_v.js /zmq/myclient.js
WORKDIR /zmq
# We assume that each client is linked to the broker
# container.
CMD node myclient $BROKER_URL $CLASSID $LOGGER_URL
