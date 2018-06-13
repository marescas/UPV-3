FROM zmq
RUN mkdir /zmq
COPY ./newworker_v.js /zmq/myworker.js
WORKDIR /zmq
# We assume that each worker is linked to the broker
# container.
CMD node myworker $BROKER_URL $CLASSID $LOGGER_URL
