pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                sh 'docker image build -t myapp:build-${BUILD_ID} .'
                sh 'docker image build --target testrunner -t myapp:testbuild-${BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:testbuild-${BUILD_ID}'
            }
        }
        stage('Deploy') {
            environment {
                DOCKER_TLS_VERIFY='1'
                COMPOSE_TLS_VERSION='TLSv1_2'
                DOCKER_CERT_PATH='/ucpbundle'
                DOCKER_HOST='tcp://ec2-54-174-122-88.compute-1.amazonaws.com:443'
            }
            steps {
                sh 'cd /ucpbundle ; eval "$(<env.sh)" ; docker service create myapp:build-${BUILD_ID}'
                //sh 'docker service create --replicas 4 nginx'
            }
        }
    }
}
